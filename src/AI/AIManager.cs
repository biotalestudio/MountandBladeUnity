using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using UnityEngine.AI;

namespace MBUnity
{
    public class AIManager : MonoBehaviour
    {
        public float radius = 25f;
        public GameObject strongestEnemy;
        public Vector3 m_currentTargetPos;
        
        private AIStates m_previousState;
        private AIStates m_currentState;

        private Party m_party;
        private NavMeshAgent m_agent;
        private BehaviorTree m_tree;
        private Animator m_animator;
        private PartyScript m_script;

        public void Awake()
        {
            m_agent = GetComponent<NavMeshAgent>();
            m_tree = GetComponent<BehaviorTree>();
            m_animator = GetComponent<Animator>();
            m_script = GetComponent<PartyScript>();

            m_party = m_script.GetParty();
            strongestEnemy = null;
        }

        public AIStates GetCurrentState()
        {
            return m_currentState;
        }

        public void SetCurrentState(AIStates newState)
        {
            m_currentState = newState;
        }

        public Vector3 GetCurrentTargetPos()
        {
            return m_currentTargetPos;
        }

        public void SetCurrentTargetPos(Vector3 newPos)
        {
            m_currentTargetPos = newPos;
        }

        public float GetDistanceWithTargetPos()
        {
            return Vector3.Distance(transform.position, m_currentTargetPos);
        }

        public bool HasArrivedToTargetPos()
        {
            if (GetDistanceWithTargetPos() < 0.1f)
            {
                OnReachedTargetPos();
                return true;
            }
            else
                return false;
        }

        void OnStartMoving()
        {
            
        }

        void OnReachedTargetPos()
        {
            m_animator.SetBool("isWalking", false);
        }

        public void MoveAgent(Vector3 targetPos)
        {
            m_currentTargetPos = targetPos;

            m_agent.SetDestination(m_currentTargetPos);
            m_animator.SetBool("isWalking", true);
        }

        public void StopMoving()
        {
            m_agent.SetDestination(transform.position);
            m_animator.SetBool("isWalking", false);
        }

        bool HasArrivedCurrentTargetPos()
        {
            if (m_agent.remainingDistance < 0.3f && !m_agent.pathPending)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    } 
}
