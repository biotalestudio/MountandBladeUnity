using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;

public class IsThereAnyEnemyNearby : Conditional
{
    public Party party;

    public SharedGameObject enemy;
    
    public Collider[] m_colliders;
    public List<GameObject > m_parties;
    public List<GameObject> m_enemies;

    public override void OnAwake()
    {
        party = GetComponent<PartyScript>().party;
    }

    public override void OnStart()
    {
        m_parties = new List<GameObject>();
        m_enemies = new List<GameObject>();
        
        m_colliders = Physics.OverlapSphere(transform.position, 22f);

        foreach (Collider obj in m_colliders)
        {
            if (obj.gameObject != gameObject)
            {
                if (obj.tag == "Party" || obj.tag == "Player")
                {
                    m_parties.Add(obj.gameObject);
                }
            }
        }

        foreach (GameObject currentParty in m_parties)
        {
            int relationShipValue = party.script.GetPartyRelationShipWithFaction(currentParty.GetComponent<PartyScript>().party.Leader.FactionData);
            if (party.script.GetPartyRelationShipWithFaction(currentParty.GetComponent<PartyScript>().party.Leader.FactionData) < -25)
            {
                m_enemies.Add(currentParty);
            }
        }
    }

    public override TaskStatus OnUpdate()
    {
        GameObject closestEnemy = ClosestEnemy();

        Debug.Log("bakiyor musun orospu cocugu");

        if (closestEnemy != null)
        {
            enemy.Value = closestEnemy;
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        }
    }

    GameObject ClosestEnemy()
    {
        GameObject closestEnemy = null;
        float smallestDistance = 25f;

        for (int i = 0; i < m_enemies.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, m_enemies[i].transform.position);
            
            if (distance < smallestDistance)
            {
                smallestDistance = distance;
                closestEnemy = m_enemies[i];
            }
        }

        return closestEnemy;
    }
}
