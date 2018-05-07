using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;

namespace MBUnity
{
    public class IsThereAnyEnemyNearby : Conditional
    {
        public Party party;
        public SharedGameObject enemy;

        public Collider[] m_colliders;
        public List<GameObject> m_enemies;

        private AIManager m_aiManager;

        public override void OnAwake()
        {
            party = GetComponent<PartyScript>().GetParty();
            m_aiManager = GetComponent<AIManager>();
        }

        public override void OnStart()
        {
            m_enemies = new List<GameObject>();
        }

        public override TaskStatus OnUpdate()
        {
            m_colliders = Physics.OverlapSphere(transform.position, 22f);
            m_aiManager.strongestEnemy = null;

            foreach (Collider obj in m_colliders)
            {
                if (obj.gameObject != gameObject)
                {
                    if (obj.tag == "Party" || obj.tag == "Player")
                    {
                        Faction partyFaction = obj.GetComponent<PartyScript>().GetPartyFaction();
                        int relationShipValue = party.script.GetPartyRelationShipWithFaction(partyFaction);
                        
                        if (relationShipValue < -25)
                        {
                            if (!m_enemies.Exists(x => x == obj.gameObject))
                                m_enemies.Add(obj.gameObject);
                            else
                                Debug.Log("Already exisstt");
                        }
                    }
                }
            }
            

            if (m_enemies.Count > 0)
            {
                GameObject strongestEnemy = FindStrongestEnemy();

                if (strongestEnemy != null)
                {
                    m_aiManager.strongestEnemy = strongestEnemy;
                    enemy.Value = strongestEnemy;
                    return TaskStatus.Success;
                }
                else
                {
                    Debug.Log("For a reason strongest enemy is null");
                    return TaskStatus.Failure;
                }
            }
            else
            {
                return TaskStatus.Failure;
            }

        }

        GameObject FindStrongestEnemy()
        {
            GameObject strongestEnemey = null;
            int bestPartyValue = 0;

            for (int i = 0; i < m_enemies.Count; i++)
            {
                int currentPartyValue = m_enemies[i].GetComponent<PartyScript>().GetPartyValue();

                if (currentPartyValue > bestPartyValue)
                {
                    bestPartyValue = currentPartyValue;
                    strongestEnemey = m_enemies[i];
                }
            }

            return strongestEnemey;
        }
    }

}