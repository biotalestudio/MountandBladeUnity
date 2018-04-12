using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Troop
{
    public Character character;
    public int size;

    public Troop (Character c, int s)
    {
        character = c;
        size = s;
    }
    
    public static bool operator==(Troop a, Troop b)
    {
        if (a.character == b.character)
            return true;
        else
            return false;
    }

    public static bool operator!=(Troop a, Troop b)
    {
        if (a.character == b.character)
            return false;
        else
            return true;
    }

}

[CreateAssetMenuAttribute(menuName = "Game/Party", fileName = "New Party")]
public class Party : ScriptableObject
{
    
    public Character Leader;
    public GameObject MapModel;
    public Banner banner;
    public PartyScript script;

    public int PartyValue;
    public bool IsPlayer;
    public bool IsBandit;
    public int Limit;
    public int Size;
    public int Morale;
    public float Speed;
    public bool HasHorse;
    public Vector3 position;

    public List<Troop> Troops;
        
    public Party followingParty;
    public Location followingLocation;

    public CurrentStatus Status;


    public enum CurrentStatus
    {
        HOLDING,
        TRAVELLING,
        PATROLLING
    }
    //public Faction Faction;
}
