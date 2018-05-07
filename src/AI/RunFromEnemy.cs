using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MBUnity
{
    public class RunFromEnemy : Action
    {
        public SharedGameObject enemy;

        private Party m_enemyParty;

        private NavMeshAgent m_agent;
        private AIManager m_aiManager;
        private Animator m_animator;

        public override void OnStart()
        {
            m_enemyParty = enemy.Value.GetComponent<PartyScript>().GetParty();

            m_agent = GetComponent<NavMeshAgent>();
            m_aiManager = GetComponent<AIManager>();
            m_animator = GetComponent<Animator>();
        }

        void Move()
        {
            Vector3 destinationDir = (transform.position - enemy.Value.transform.position);

            Vector3 destinationPoint = transform.position + destinationDir;

            destinationPoint = new Vector3(destinationPoint.x, transform.position.y, destinationPoint.z);

            NavMeshHit hit;

            NavMesh.SamplePosition(destinationPoint, out hit, 10f, 1);

            m_aiManager.MoveAgent(hit.position);

            m_animator.SetBool("isWalking", true);
        }


        public override TaskStatus OnUpdate()
        {
            float distance = m_aiManager.GetDistanceWithTargetPos();

            if (distance >= 20f)
            {
                m_animator.SetBool("isWalking", false);
                enemy.Value = null;
                m_aiManager.SetCurrentState(AIStates.PATROLLING);
                return TaskStatus.Success;
            }
            else
            {
                Move();
                m_aiManager.SetCurrentState(AIStates.RUNNING);
                return TaskStatus.Running;
            }
        }
    }

}