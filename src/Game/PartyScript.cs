using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyScript : MonoBehaviour
{
    public Party party;

    [Header("Factions")]
    public Faction Swadia;
    public Faction Khergit;
    public Faction Nords;
    
    private Character m_leader;
    
    void Start()
    {
        Init();
    }
    

    void Update()
    {
        party.position = gameObject.transform.position;
    }
    
    //<summary>
    //Basic setup for all parties in the game
    //</summary>
    void Init()
    {
        m_leader = party.Leader;
        party.script = this;

        CalculatePartyLimit();

        if (!party.IsBandit)
        {
            party.Troops = new List<Troop>();
            party.Size = 0;
            AddCharacterToParty(party.Leader);
        }


        if (party.Leader.IsLord)
        {
            AddSoldiersToLordParty();
            //TeleportToLocationOwned();
        }

        CalculatePartyValue();
    }
    
    public int GetPartyRelationShipWithFaction(Faction faction)
    {
        foreach (FactionRelationship relationship in party.Leader.FactionData.RelationshipList)
        {
            if (relationship.faction == faction)
            {
                return relationship.relationshipValue;
            }
            else
            {
                continue;
            }
        }

        return 0;
    }

    //<summary>
    //A simple formula that calculates party's limit
    //<summary>
    public void CalculatePartyLimit()
    {
        int newLimit = 30 + (m_leader.Leadership * 5) + (m_leader.Charisma) + (m_leader.Renown / 10);
        party.Limit = newLimit;
    }

    public void CalculatePartyValue()
    {
        party.PartyValue = 0;

        foreach (Troop troop in party.Troops)
        {
            party.PartyValue += (troop.character.CharValue * troop.size);    
        }
    }

    //<summary>
    //This function adds randomized amount of soldiers into the lord's party
    //How much soldiers will add depends on Lord's various stats
    //<summary>
    void AddSoldiersToLordParty()
    {
        if (m_leader.FactionData == Swadia)
        {
            for (int i = 0; i < Swadia.FactionTroops.Count; i++)
            {
                int troopSize = Random.Range(party.Limit / (10 + (i * 3)), party.Limit / (5 + (i * 2)));
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
        gameObject.SetActive(false);
        location.script.AddPartyTroopsToGarrison(party);
    }

    public void ExitLocation(Location location)
    {
        location.script.RemovePartyTroopsFromGarrison(party);
        gameObject.SetActive(true);
    }

    public void TeleportToLocationOwned()
    {
        transform.position = m_leader.LocationsOwned[0].position;
        EnterLocation(m_leader.LocationsOwned[0]);
    }

    public void AddCharacterToParty(Character character)
    {
        //Search through all list and see if this character is already exists in our Party
        if ((party.Size < party.Limit))
        {
            for (int i = 0; i < party.Troops.Count; i++)
            {
                if (party.Troops[i].character.IsEqual(character))
                {
                    int troopSize = party.Troops[i].size;
                    if (!(party.Limit > party.Size))
                    {
                        return;
                    }
                    party.Troops[i] = new Troop(character, troopSize += 1);
                    party.Size += 1;
                    return;
                }
            }

            //If it is not just add this character to our list as a troop 
            party.Troops.Add(new Troop(character, 1));
            party.Size += 1;
        }
        else
            Debug.Log("Party is full");
    }

    //Overloaded version of the function
    //Allows us to add a specific amount of soldier to our party
    public void AddCharacterToParty(Character character, int size)
    {
        if ((party.Size + size < party.Limit))
        {
            for (int i = 0; i < party.Troops.Count; i++)
            {
                if (party.Troops[i].character.IsEqual(character))
                {
                    int troopSize = party.Troops[i].size;
                    party.Troops[i] = new Troop(character, troopSize += size);
                    party.Size += size;
                    return;
                }
            }

            party.Troops.Add(new Troop(character, size));
            party.Size += size;
        }
        else
            Debug.Log("Party is full");
    }
}
