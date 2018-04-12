using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;

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

    bool HasArrived()
    {
        if (!m_agent.pathPending && m_agent.remainingDistance < 0.5f)
        {
            m_animator.SetBool("isWalking", false);
            return true;
        }
        else
        {
            m_animator.SetBool("isWalking", true);
            return false;
        }
            
    }
    
    public override TaskStatus OnUpdate()
    {
        if (HasArrived())
            return TaskStatus.Success;
        else
            return TaskStatus.Running;
    }

}
