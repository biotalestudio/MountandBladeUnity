using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using UnityEngine.AI;

namespace MBUnity
{
    public class PickRandomPositionOnNavMesh : Action
    {
        public SharedVector3 targetPosition;
        public SharedVector3 spawnPoint;
        public SharedGameObject enemy;

        public float radius = 25f;
        
        public override void OnStart()
        {
            PickRandomPosition();
        }

        TaskStatus PickRandomPosition()
        {
            Vector3 finalPosition;

            Vector3 positionDir = Random.insideUnitSphere * radius;

            positionDir += spawnPoint.Value;

            NavMeshHit hit;

            NavMesh.SamplePosition(positionDir, out hit, radius, 1);

            finalPosition = hit.position;

            if ((transform.position.y - finalPosition.y) > 5f)
            {
                PickRandomPosition();
                return TaskStatus.Running;
            }

            if (enemy.Value != null)
            {
                float currentDistance = Vector3.Distance(transform.position, enemy.Value.transform.position);

                float newDistance = Vector3.Distance(transform.position, finalPosition);

                if (newDistance < currentDistance)
                {
                    PickRandomPosition();
                    return TaskStatus.Running;
                }
            }

            targetPosition.Value = finalPosition;
            
            if (finalPosition != null)
                return TaskStatus.Success;
            else
                return TaskStatus.Failure;
        }
    }

}