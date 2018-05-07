using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;

namespace MBUnity
{
    public class BanditSpawner : MonoBehaviour
    {
        public GameObject partyPrefab;
        public Character banditCharacter;
        public int maxBandit;
        public float sphereRadius = 10f;

        private BehaviorTree m_patrolTree;
        private GameObject m_spawnedBandit;
        private int m_currentBanditCount;
        

        private void Update()
        {
            if (m_currentBanditCount < maxBandit)
            {
                SpawnBandit();
            }
        }

        Vector3 RandomPositionOnNavMesh()
        {
            Vector3 randomDir = Random.insideUnitSphere * sphereRadius;

            randomDir += transform.position;

            NavMeshHit hit;
            NavMesh.SamplePosition(randomDir, out hit, sphereRadius, 1);
            Vector3 position = hit.position;

            return position;
        }

        void SpawnBandit()
        {
            Party party = ScriptableObject.CreateInstance<Party>();
            GameObject spawnedObject = Instantiate(partyPrefab, RandomPositionOnNavMesh(), transform.rotation);
            spawnedObject.transform.parent = transform;
            PartyScript partyScript = spawnedObject.GetComponent<PartyScript>();
            PartyUIInteraction partyUI = spawnedObject.GetComponent<PartyUIInteraction>();
            m_patrolTree = spawnedObject.GetComponent<BehaviorTree>();


            party.IsBandit = true;
            party.Leader = banditCharacter;
            party.script = partyScript;
            
            partyScript.SetParty(party);
            Debug.Log("Ready to enable");
            partyScript.enabled = true;

            partyUI.partyData = party;
            partyUI.enabled = true;

            if (party.Troops == null)
                party.Troops = new List<Troop>();

            int randomSize = Random.Range(5, 20);
            party.Limit = 999;
            partyScript.AddCharacterToParty(party.Leader, randomSize);
            m_patrolTree.SetVariableValue("spawnPoint", transform.position);
            
            m_currentBanditCount++;
        }
    }

}