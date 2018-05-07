using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBUnity
{
    [System.Serializable]
    public struct FactionRelationship
    {
        public Faction faction;
        public int relationshipValue;

        public FactionRelationship(Faction f, int r)
        {
            faction = f;
            relationshipValue = r;
        }
    }

    [CreateAssetMenu(fileName = "New Faction", menuName = "Game/Faction")]
    public class Faction : ScriptableObject
    {
        public string Name;
        public Character Leader;
        public Color Color;
        public List<FactionRelationship> RelationshipList;
        public List<Location> LocationsOwned;
        public List<Character> FactionTroops;

        private void Awake()
        {
        }

        private void OnEnable()
        {
            SortTroopList();
        }

        //Simple Selection Sort algorithm
        //Can be optimized greatly
        //Actually we don't need this kind of sorting
        //We can do this sorting manually in the editor
        //But I am a lazy person so...
        void SortTroopList()
        {
            for (int i = 0; i < FactionTroops.Count; i++)
            {
                int minIndex = i;

                Character tempChar;

                for (int j = i + 1; j < FactionTroops.Count; j++)
                {
                    if (FactionTroops[minIndex].CharValue > FactionTroops[j].CharValue)
                    {
                        minIndex = j;
                    }
                }

                //Swapping
                if (minIndex != i)
                {
                    tempChar = FactionTroops[minIndex];

                    FactionTroops[minIndex] = FactionTroops[i];
                    FactionTroops[i] = tempChar;
                }
            }
        }
    }

}