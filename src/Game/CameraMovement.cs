using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBUnity
{
    public class CameraMovement : MonoBehaviour
    {

        [Header("Camera")]
        public float cameraMovementSpeed = 25f;
        public float cameraScrollSpeed = 50f;
        public float cameraRotateSpeed = 50f;
        public float pivotMoveSmoothTime = 0.3f;
        public float pivotRotateSmoothTime = 0.5f;
        public float pivotRotateSpeed;
        public float slerpSmoothing;

        [Header("Limits")]
        public float minYValue;
        public float maxYValue;
        public float maxXRotation;
        public float minXRotation;
        public bool isVerticalpositionChanged;

        //Objects
        private Transform m_pivot;
        private Camera m_camera;
        private GameObject m_player;
        private Rigidbody m_rigidbody;

        //Inputs
        private float m_horizontal;
        private float m_vertical;
        private float m_mouseWheel;
        private float pivotMoveSmoothV = 0.1f;
        private float pivotRotateSmoothV = 0.1f;

        private float m_speedUpX = 1f;
        private float m_speedUpz = 1f;
        private float m_smoothX;

        private Vector3 m_lastMousePosition;
        private float m_pivotNewXRotation;
        private Vector3 m_holderNewPosition;
        [SerializeField]
        private Vector3 m_cameraDirection;
        private float m_moveMultiplier;




        static private bool isFocusing = false;

        // Use this for initialization
        void Start()
        {
            m_pivot = Camera.main.transform.parent;
            m_player = GameObject.FindGameObjectWithTag("Player");
            m_camera = Camera.main;
            m_rigidbody = GetComponent<Rigidbody>();
        }

        static void FocusOnPlayer(GameObject player, GameObject camera)
        {
            if (Vector3.Distance(player.transform.position, camera.transform.position) >= (camera.transform.position.y - player.transform.position.y) + 15f)
            {
                Vector3 newPosition = new Vector3(player.transform.position.x, camera.transform.position.y, player.transform.position.z);
                camera.transform.position = Vector3.MoveTowards(camera.transform.position, newPosition, 50f * Time.deltaTime);
                Vector3 rotateDir = player.transform.position - camera.transform.position;
                Quaternion rotateToPlayer = Quaternion.LookRotation(rotateDir);
                camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, rotateToPlayer, Time.deltaTime * 10f);
                isFocusing = true;
            }
            else
            {
                isFocusing = false;
            }

        }

        // Update is called once per frame
        void LateUpdate()
        {

            m_horizontal = Input.GetAxis("Horizontal");
            m_vertical = Input.GetAxis("Vertical");

            if (Input.GetKeyDown(KeyCode.F) || isFocusing)
            {
                FocusOnPlayer(m_player, gameObject);
            }


            if ((m_horizontal != 0 || m_vertical != 0) && !GameManager.Instance.IsPaused())
                Move(m_horizontal, m_vertical);


            //Scrolling and Rotating the camera
            m_mouseWheel = Input.GetAxis("Mouse ScrollWheel");

            if (m_mouseWheel != 0 && !GameManager.Instance.IsPaused())
            {
                MoveHolderUp();
                RotatePivot();
            }

            if (Input.GetMouseButton(1))
            {
                float mouseX = Input.GetAxis("Mouse X");

                Vector3 rotateDir = transform.rotation.eulerAngles;

                Vector3 currentMousePosition = Input.mousePosition;
                currentMousePosition.z = 0f;
                m_lastMousePosition.z = 0f;
                currentMousePosition.y = 0f;
                m_lastMousePosition.y = 0f;


                float distance = currentMousePosition.x - m_lastMousePosition.x;
                RotateCameraY(distance);
            }
            m_lastMousePosition = Input.mousePosition;
        }

        void MoveHolderUp()
        {
            if (transform.position.y >= minYValue && transform.position.y <= maxYValue)
            {
                m_holderNewPosition = transform.position;

                float change = m_mouseWheel * 20f;

                m_holderNewPosition.y -= change;

                transform.position = Vector3.Lerp(transform.position, m_holderNewPosition, 0.8f * Time.deltaTime * 500f * cameraScrollSpeed);

                if (transform.position.y < minYValue)
                {
                    transform.position = new Vector3(transform.position.x, minYValue, transform.position.z);
                }
                else if (transform.position.y > maxYValue)
                {
                    transform.position = new Vector3(transform.position.x, maxYValue, transform.position.z);
                }
            }
        }

        void RotatePivot()
        {
            Quaternion curRotation = m_pivot.transform.localRotation;

            float curXAngle = curRotation.eulerAngles.x;
            curXAngle = (curXAngle > 180) ? (curXAngle - 360) : curXAngle;

            if (curXAngle <= (maxXRotation + 1) && curXAngle >= minXRotation)
            {
                m_pivotNewXRotation = curRotation.eulerAngles.x;

                float change = (m_mouseWheel * pivotRotateSpeed);

                m_pivotNewXRotation -= change;

                Vector3 newRot = new Vector3(m_pivotNewXRotation, curRotation.eulerAngles.y, curRotation.eulerAngles.z);
                m_pivot.transform.localRotation = Quaternion.Slerp(m_pivot.localRotation, Quaternion.Euler(newRot), 500f * Time.deltaTime * cameraRotateSpeed);

                float xAngle = m_pivot.transform.rotation.eulerAngles.x;
                xAngle = (xAngle > 180) ? xAngle - 360 : xAngle;

                if (xAngle > maxXRotation)
                {
                    m_pivot.transform.localRotation = Quaternion.Euler(new Vector3(maxXRotation, 0f, 0f));
                }
                else if (xAngle < minXRotation)
                {
                    m_pivot.transform.localRotation = Quaternion.Euler(new Vector3(minXRotation, 0f, 0f));
                }
            }
        }

        void Move(float horizontal, float vertical)
        {
            Vector3 vVertical = vertical * transform.forward;
            Vector3 hHorizontal = horizontal * transform.right;

            m_cameraDirection = (vVertical + hHorizontal).normalized;

            float yPos = transform.position.y;

            yPos /= 15f;

            yPos = Mathf.Clamp(yPos, 1f, 10f);

            Vector3 newPos = (transform.position + (m_cameraDirection * Time.deltaTime * cameraMovementSpeed * yPos));

            transform.position = Vector3.Lerp(transform.position, newPos, 0.8f);
        }

        void RotateCameraX(float oldPosY, float newPosY)
        {
            Vector3 rot = transform.rotation.eulerAngles;

            if (rot.x < 80 && rot.x > 30)
            {
                float change = newPosY - oldPosY;
                rot.x += change;
                if (rot.x < 30f)
                    rot.x = 31f;
                else if (rot.x > 80f)
                    rot.x = 79f;

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rot), 0.75f);
            }

        }

        void RotateCameraY(float distance)
        {
            Vector3 rotateDir = transform.rotation.eulerAngles;
            rotateDir.y += (distance * cameraRotateSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rotateDir), .1f);
        }

    }

}