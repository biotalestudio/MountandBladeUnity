using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBUnity
{
    public class LocationScript : MonoBehaviour
    {
        public static int counter = 0;

        public Location locationData;

        private Faction m_faction;
        private Character m_ruler;
        
        void Start()
        {
            m_faction = locationData.Ruler.FactionData;
            m_ruler = locationData.Ruler;
            locationData.position = transform.position;
            locationData.GarrisonSize = 0;
            locationData.script = this;

            if (locationData.Garrison == null)
                locationData.Garrison = new List<Troop>();
            else
                locationData.Garrison.Clear();

            if (locationData.Parties == null)
                locationData.Garrison = new List<Troop>();
            else
                locationData.Garrison.Clear();

            if (m_ruler.LocationsOwned == null)
                m_ruler.LocationsOwned = new List<Location>();
            else
                m_ruler.LocationsOwned.Clear();


            m_ruler.LocationsOwned.Add(locationData);
            AddSoldiersToGarrison();
        }

        public void AddPartyTroopsToGarrison(Party party)
        {

            for (int i = 0; i < party.Troops.Count; i++)
            {
                bool exist = false;

                for (int j = 0; j < locationData.Garrison.Count; j++)
                {
                    if (locationData.Garrison[j] == party.Troops[i])
                    {
                        int newSize;
                        newSize = locationData.Garrison[j].size + party.Troops[i].size;

                        locationData.Garrison[j] = new Troop(party.Troops[i].character, newSize);
                        exist = true;
                    }
                }

                if (!exist)
                {
                    locationData.Garrison.Add(party.Troops[i]);
                }
            }

            locationData.Parties.Add(party);
        }
        
        public void RemovePartyTroopsFromGarrison(Party party)
        {
            for (int i = 0; i < party.Troops.Count; i++)
            {
                for (int j = 0; j < locationData.Garrison.Count; j++)
                {
                    if (locationData.Garrison[j] == party.Troops[i])
                    {
                        int newSize = locationData.Garrison[j].size - party.Troops[i].size;
                        if (newSize <= 0)
                        {
                            locationData.Garrison.Remove(locationData.Garrison[j]);
                        }
                        else
                        {
                            locationData.Garrison[j] = new Troop(party.Troops[i].character, newSize);
                        }

                    }
                }
            }

            locationData.Parties.Remove(party);
        }

        public void AddSoldiersToGarrison()
        {
            switch (locationData.Type)
            {
                case Enums.LocationType.City:
                    for (int i = 0; i < m_faction.FactionTroops.Count; i++)
                    {
                        int capitalBuff = 1;

                        if (locationData.IsCapital)
                            capitalBuff = 2;

                        int troopSize = Random.Range((m_ruler.PartyData.Limit) / (4 + (i * 2)), (locationData.Ruler.PartyData.Limit * capitalBuff) / (3 + (i * 2)));

                        if (i > 5)
                        {
                            AddCharacterToGarrison(m_faction.FactionTroops[i], troopSize * 2);
                            continue;
                        }
                        AddCharacterToGarrison(m_faction.FactionTroops[i], troopSize);
                    }
                    break;
                case Enums.LocationType.Castle:
                    break;
            }
        }

        public void AddCharacterToGarrison(Character character, int size)
        {
            if (locationData.Garrison.Count != 0)
            {
                for (int i = 0; i < locationData.Garrison.Count; i++)
                {
                    if (locationData.Garrison[i].character.IsEqual(character))
                    {
                        int troopSize = locationData.Garrison[i].size;
                        locationData.Garrison[i] = new Troop(character, troopSize + size);
                        locationData.GarrisonSize += (locationData.Garrison[i].size);
                    }
                    else
                    {
                        locationData.Garrison.Add(new Troop(character, size));
                        locationData.GarrisonSize += size;
                        return;
                    }
                }
            }
            else
            {
                locationData.Garrison.Add(new Troop(character, size));
                locationData.GarrisonSize += size;
            }
        }
    } 
}
