using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MBUnity.Enums;

namespace MBUnity
{
    [CreateAssetMenu(fileName = "New Location", menuName = "Game/Location")]
    public class Location : ScriptableObject
    {
        public string Name;
        public string sceneName;

        public int PowerValue;
        public int GarrisonSize;

        public bool IsCapital;

        public Vector3 position;

        public Character Ruler;

        public LocationType Type;
        public LocationScript script;

        public List<Troop> Garrison;
        public List<Party> Parties;
    } 
}
