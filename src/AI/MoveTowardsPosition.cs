using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;

namespace MBUnity
{
    public class MoveTowardsPosition : Action
    {
        public SharedVector3 targetPosition;
        
        private NavMeshAgent m_agent;
        private Animator m_animator;
        private AIManager m_aiManager;

        public override void OnStart()
        {
            m_agent = GetComponent<NavMeshAgent>();
            m_animator = GetComponent<Animator>();
            m_aiManager = GetComponent<AIManager>();
            
            m_aiManager.MoveAgent(targetPosition.Value);
        }
        
        public override TaskStatus OnUpdate()
        {
            if (m_aiManager.strongestEnemy != null)
            {
                Debug.Log("There is an enemy nearby");
                m_aiManager.StopMoving();
                return TaskStatus.Failure;
            }
            else if (m_aiManager.HasArrivedToTargetPos())
            {
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Running;
        }

    }

}