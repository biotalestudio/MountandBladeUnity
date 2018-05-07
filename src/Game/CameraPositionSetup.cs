using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBUnity
{
    public class CameraPositionSetup : MonoBehaviour
    {

        [SerializeField]
        GameObject terrainObject;

        // Update is called once per frame
        void FixedUpdate()
        {
            RaycastHit rayHit;

            if (Physics.Raycast(transform.position, Vector3.down, out rayHit, 3f))
            {
                if (rayHit.collider.gameObject == terrainObject)
                {
                    float distance = Vector3.Distance(rayHit.point, transform.position);
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + distance, transform.position.z), 0.3f);
                }
            }
        }
    }

}