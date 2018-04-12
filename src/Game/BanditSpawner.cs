using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BanditSpawner : MonoBehaviour
{
    public GameObject partyPrefab;
    public Character banditCharacter;

    public float sphereRadius = 10f;

    private PartyUIInteraction m_uiInteraction;
    private PartyScript m_script;
    private GameObject m_spawnedBandit;
    private Party m_party;
    private int banditCount;

	void Awake ()
    {
        SpawnBandit();
        SpawnBandit();
        SpawnBandit();
        SpawnBandit();
    }

    private void Update()
    {
        
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
        m_party = ScriptableObject.CreateInstance<Party>();
        
        m_party.IsBandit = true;
        m_party.Leader = banditCharacter;

        m_spawnedBandit = Instantiate(partyPrefab, RandomPositionOnNavMesh(), transform.rotation);
        
        m_uiInteraction = m_spawnedBandit.GetComponent<PartyUIInteraction>();
        m_party.script = m_spawnedBandit.GetComponent<PartyScript>();
        m_script = m_party.script;
        
        m_script.party = m_party;
        m_uiInteraction.partyData = m_party;

        m_uiInteraction.enabled = true;
        m_script.enabled = true;

        if (m_party.Troops == null)
            m_party.Troops = new List<Troop>();
        
        int randomSize = Random.Range(5, 20);
        m_party.Limit = 999;
        m_script.AddCharacterToParty(m_party.Leader, randomSize);
    }
}
