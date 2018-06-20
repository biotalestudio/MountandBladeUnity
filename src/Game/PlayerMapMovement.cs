using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MBUnity.Enums;

namespace MBUnity
{
    public class PlayerMapMovement : MonoBehaviour
    {

        public static bool IsMovingTowardsParty = false;

        public Party PlayerParty;

        private Vector3 m_destinationPoint;

        private float m_yAxis;

        private bool m_hasClicked;

        private bool m_isMoving;

        private NavMeshAgent m_agent;

        private Camera m_mainCamera;

        private Animator m_animator;

        // Use this for initialization
        void Start()
        {
            m_yAxis = transform.position.y;
            PlayerParty.FollowingParty = null;
            m_mainCamera = Camera.main;

            m_agent = GetComponent<NavMeshAgent>();

            m_animator = GetComponentInChildren<Animator>();

            GameManager.Instance.SetState(GameManager.GameState.SIMULATING);
        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit rayHit;

                Ray ray;

                ray = m_mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out rayHit) && !GameManager.Instance.IsPaused())
                {
                    m_destinationPoint = rayHit.point;

                    m_hasClicked = true;

                    m_agent.SetDestination(rayHit.point);

                    if (m_hasClicked)
                    {
                        m_isMoving = true;
                        if ((PartyUIInteraction.IsOverOnParty == true) && (!PartyUI.partyData.IsPlayer))
                        {
                            PlayerParty.FollowingParty = PartyUI.partyData;
                            PlayerParty.FollowingLocation = null;
                            IsMovingTowardsParty = true;
                        }
                        else if (LocationUIInteraction.IsOverOnLocation == true)
                        {
                            PlayerParty.FollowingParty = null;
                            PlayerParty.FollowingLocation = LocationUI.LocationData;
                        }
                        else
                        {
                            PlayerParty.FollowingParty = null;
                            IsMovingTowardsParty = false;
                            PlayerParty.FollowingParty = null;
                            PlayerParty.FollowingLocation = null;
                        }
                        PlayerParty.CurrentStatus = PartyStatus.Travelling;

                        m_animator.SetBool("isWalking", true);
                    }
                }
            }

            if (m_hasClicked)
            {
                Move();
                //RotatePlayer();
            }
        }

        void Move()
        {
            //I know this condition looks stupid but calculation of a destination takes some time
            //And before it sets a destination it comes to this condition and reads remaningDistance as 0
            if (m_hasClicked && (!(m_agent.remainingDistance == 0f) && (m_agent.remainingDistance < 0.1f)))
            {
                if (PlayerParty.FollowingParty)
                {
                    //Open Dialog Menu with this party's leader
                }
                else if (PlayerParty.FollowingLocation)
                {
                    //Open Location Menu
                    GameManager.Instance.SetLocationSceneUIData(PlayerParty.FollowingLocation);
                    GameManager.Instance.SetState(GameManager.GameState.PAUSED);
                    GameManager.Instance.ActivateLocationSceneUI();
                }

                m_hasClicked = false;
                m_isMoving = false;
                IsMovingTowardsParty = false;
                PlayerParty.FollowingParty = null;
                PlayerParty.FollowingLocation = null;
                PlayerParty.CurrentStatus = PartyStatus.Holding;
                m_animator.SetBool("isWalking", false);
            }

        }

        void RotatePlayer()
        {
            Vector3 dir = m_destinationPoint - transform.position;
            Quaternion rotationToLook = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotationToLook, Time.deltaTime * 8f);
        }
    } 
}
