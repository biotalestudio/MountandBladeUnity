using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class ChaseEnemy : Action
{
    public SharedGameObject enemy;
    public SharedVector3 targetPosition;

    private Party m_party;
    private Party m_enemyParty;

    private PartyScript m_partyScript;
    private PartyScript m_enemyScript;

    private AIManager m_aiManager;
    private Animator m_animator;
    private NavMeshAgent m_agent;
    
    public override void OnStart()
    {
        m_aiManager = GetComponent<AIManager>();
        m_animator = GetComponent<Animator>();
        m_agent = GetComponent<NavMeshAgent>();

        m_partyScript = GetComponent<PartyScript>();
        m_enemyScript = enemy.Value.GetComponent<PartyScript>();

        m_party = m_partyScript.party;
        m_enemyParty = m_enemyScript.party;
    }

    public override TaskStatus OnUpdate()
    {
        Debug.Log("distance is: " + m_aiManager.GetDistanceWithTargetPos());
        if (m_aiManager.GetDistanceWithTargetPos() < 0.3f)
        {
            Debug.Log("Got the enemy");
            Debug.Log("Start the fight");
            m_animator.SetBool("isWalking", false);
            m_aiManager.currentState = AIStates.PATROLLING;
            return TaskStatus.Success;
        }
        else
        {
            Move();
            Debug.Log("Chasing the enemy");
            return TaskStatus.Success;
        }
    }

    void Move()
    {
        Vector3 enemyPosition = enemy.Value.transform.position;

        targetPosition.Value = enemyPosition;

        m_aiManager.MoveAgent(targetPosition.Value);

        m_animator.SetBool("isWalking", true);
    }

}
