using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using UnityEngine.AI;

public class AIManager : MonoBehaviour
{
    public AIStates currentState;
    public Vector3 currentTargetPos;
    public Party party;

    public Collider[] m_colliders;
    public List<GameObject> m_parties;
    public List<GameObject> m_enemies;

    public float radius = 25f;
    public GameObject closestEnemy;

    private AIStates previousState;
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

        party = m_script.party;
    }

    public void MoveAgent(Vector3 targetPos)
    {
        currentTargetPos = targetPos;

        m_agent.SetDestination(currentTargetPos);
        m_animator.SetBool("isWalking", true);
    }

    private void Update()
    {
        
    }

    public float GetDistanceWithTargetPos()
    {
        float distance = Vector3.Distance(transform.position, currentTargetPos);

        return distance; 
    }
    
}
