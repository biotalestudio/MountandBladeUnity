using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MBUnity.Enums;

namespace MBUnity
{
    public class PartyScript : MonoBehaviour
    {
        [SerializeField]
        private Party m_party;

        public GameObject modelObject;
        public GameObject textObject;

        [Header("Factions")]
        public Faction Swadia;
        public Faction Khergit;
        public Faction Nords;
        
        private Character m_leader;
        private Location m_currentLocation;
        private Collider m_collider;
        
        public void SetFollowingParty(Party partyToFollow)
        {
            m_party.FollowingParty = partyToFollow; 
        }

        public Party GetFollowingParty()
        {
            return m_party.FollowingParty;
        }
        
        public Party GetParty()
        {
            return m_party;
        }

        public void SetParty(Party newParty)
        {
            m_party = newParty;
        }

        public Faction GetPartyFaction()
        {
            return m_party.Leader.FactionData;
        }
        
        public bool GetIsPlayer()
        {
            return m_party.IsPlayer;
        }

        public bool GetIsBandit()
        {
            return m_party.IsBandit;
        }
        
        public PartyStatus GetCurrentStatus()
        {
            return m_party.CurrentStatus;
        }

        public void SetCurrentStatus(PartyStatus newStatus)
        {
            m_party.CurrentStatus = newStatus;
        }

        public Character GetPartyLeader()
        {
            return m_party.Leader;
        }

        public int GetPartyValue()
        {
            return m_party.PartyValue;
        }

        void Start()
        {
            Init();
        }
        
        void Update()
        {
            m_party.position = gameObject.transform.position;
        }

        //<summary>
        //Basic setup for all parties in the game
        //</summary>
        void Init()
        {
            m_leader = m_party.Leader;
            m_party.script = this;
            m_collider = GetComponent<BoxCollider>();

            CalculatePartyLimit();


            if (!m_party.IsBandit)
            {
                m_party.Troops = new List<Troop>();
                m_party.Size = 0;
                AddCharacterToParty(m_party.Leader);
            }


            if (m_party.Leader.IsLord)
            {
                AddSoldiersToLordParty();
            }

            CalculatePartyValue();
        }

        public int GetPartyRelationShipWithFaction(Faction faction)
        {
            foreach (FactionRelationship relationship in m_party.Leader.FactionData.RelationshipList)
            {
                if (relationship.faction == faction)
                {
                    return relationship.relationshipValue;
                }
            }

            return 0;
        }

        //<summary>
        //A simple formula that calculates party's limit
        //</summary>
        public void CalculatePartyLimit()
        {
            int newLimit = 30 + (m_leader.Leadership * 5) + (m_leader.Charisma) + (m_leader.Renown / 10);
            m_party.Limit = newLimit;
        }

        public void CalculatePartyValue()
        {
            m_party.PartyValue = 0;

            foreach (Troop troop in m_party.Troops)
            {
                m_party.PartyValue += (troop.character.CharValue * troop.size);
            }
        }

        //<summary>
        //This function adds randomized amount of soldiers into the lord's party
        //How much soldiers will add depends on Lord's various stats
        //</summary>
        void AddSoldiersToLordParty()
        {
            if (m_leader.FactionData == Swadia)
            {
                for (int i = 0; i < Swadia.FactionTroops.Count; i++)
                {
                    int troopSize = Random.Range(m_party.Limit / (10 + (i * 3)), m_party.Limit / (5 + (i * 2)));
                    if (i > 6 && m_leader.Renown >= 500)
                    {
                        AddCharacterToParty(Swadia.FactionTroops[i], troopSize * 2);
                        continue;
                    }
                    AddCharacterToParty(Swadia.FactionTroops[i], troopSize);
                }
            }
        }

        public void EnterLocation(Location location)
        {
            location.script.AddPartyTroopsToGarrison(m_party);
            m_currentLocation = location;
            modelObject.SetActive(false);
            textObject.SetActive(false);
            m_collider.enabled = false;
        }

        public void ExitLocation(Location location)
        {
            location.script.RemovePartyTroopsFromGarrison(m_party);
            m_currentLocation = null;
            modelObject.SetActive(true);
            textObject.SetActive(true);
            m_collider.enabled = true;
        }

        public Location GetCurrentLocation()
        {
            return m_currentLocation;
        }

        public void SetCurrentLocation(Location newLocation)
        {
            m_currentLocation = newLocation;
        }

        public void TeleportToLocationOwned()
        {
            transform.position = m_leader.LocationsOwned[0].position;
            //EnterLocation(m_leader.LocationsOwned[0]);
        }

        public void AddCharacterToParty(Character character)
        {
            //Search through all list and see if this character is already exists in our Party
            if ((m_party.Size < m_party.Limit))
            {
                for (int i = 0; i < m_party.Troops.Count; i++)
                {
                    if (m_party.Troops[i].character.IsEqual(character))
                    {
                        int troopSize = m_party.Troops[i].size;
                        if (!(m_party.Limit > m_party.Size))
                        {
                            return;
                        }
                        m_party.Troops[i] = new Troop(character, troopSize += 1);
                        m_party.Size += 1;
                        return;
                    }
                }

                //If it is not just add this character to our list as a troop 
                m_party.Troops.Add(new Troop(character, 1));
                m_party.Size += 1;
            }
            else
                Debug.Log("Party is full");
        }

        //Overloaded version of the function
        //Allows us to add a specific amount of soldier to our party
        public void AddCharacterToParty(Character character, int size)
        {
            if ((m_party.Size + size < m_party.Limit))
            {
                for (int i = 0; i < m_party.Troops.Count; i++)
                {
                    if (m_party.Troops[i].character.IsEqual(character))
                    {
                        int troopSize = m_party.Troops[i].size;
                        m_party.Troops[i] = new Troop(character, troopSize += size);
                        m_party.Size += size;
                        return;
                    }
                }

                m_party.Troops.Add(new Troop(character, size));
                m_party.Size += size;
            }
            else
                Debug.Log("Party is full");
        }
    } 
}
