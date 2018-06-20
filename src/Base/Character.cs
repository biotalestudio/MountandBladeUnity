using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBUnity
{
    [CreateAssetMenu(fileName = "New Character", menuName = "Game/Character")]
    public class Character : ScriptableObject
    {
        [Header("Primary")]
        public string Name;
        public int Level;
        public int Health;
        public int Experience;
        public int NextLevelExperience;
        public int Age;
        public int Renown;
        public int Honor;
        public Sex CharacterSex;
        public int CharValue;

        [Header("Game")]
        public int Gold;
        public bool IsLord;
        public bool IsCompanion;
        public List<Item> Inventory;
        public List<Location> LocationsOwned;
        
        public bool IsEqual(Character c1)
        {
            return this.Equals(c1);
        }

        public enum Sex
        {
            MALE,
            FEMALE
        }

        [Header("Data")]
        public Faction FactionData;
        public Party PartyData;

        [Header("Attributes")]
        public int Strength;
        public int Agility;
        public int Intelligence;
        public int Charisma;

        [Header("Skills")]
        public int Ironflesh;
        public int PowerStrike;
        public int PowerThrow;
        public int PowerDraw;
        public int WeaponMaster;
        public int Shield;
        public int Athletics;
        public int Riding;
        public int HorseArchery;
        public int Looting;
        public int Trainer;
        public int Tracking;
        public int Tactics;
        public int PathFinding;
        public int Spotting;
        public int InventoryManagement;
        public int WoundTreatment;
        public int Surgery;
        public int FirstAid;
        public int Engineer;
        public int Persuasion;
        public int PrisonerManagement;
        public int Leadership;
        public int Trade;

        [Header("Proficiencies")]
        public int OneHandedWeapon;
        public int TwoHandedWeapon;
        public int Polearms;
        public int Archery;
        public int Crossbow;
        public int Throwing;

        [Header("Points")]
        public int AttributePoints;
        public int SkillPoints;
        public int WeaponPoints;

        [Header("Upgrades")]
        public Character upgrade01;
        public Character upgrade02;

        //Use functions in this script only if it is going to initialize a value in scriptable object
        public void OnEnable()
        {
            Init();
        }

        void Init()
        {
            CalculateCharacterValue();
            CalculateNextLevelExperience();
        }

        public void CalculateNextLevelExperience()
        {
            Experience = (600 * (Level) + (80 * (Level)));

            NextLevelExperience = (600 * (Level + 1) + (80 * (Level + 1)));
        }

        //We use Character value for pretty much everything in the game
        //From sorting troops in UI, to AI algorithms
        //It is an integer reperansation of how powerful a character is
        public void CalculateCharacterValue()
        {
            CharValue = 1;

            CharValue += (Level * 6);
            CharValue += Health;
            CharValue += Renown;

            CharValue += (Strength * 5);
            CharValue += (Agility * 5);
            CharValue += (Charisma * 5);
            CharValue += (Intelligence * 5);

            CharValue += (Ironflesh * 2);
            CharValue += (PowerStrike * 2);
            CharValue += (PowerThrow * 2);
            CharValue += (PowerDraw * 2);
            CharValue += (WeaponMaster * 2);
            CharValue += (Shield * 2);
            CharValue += (Riding * 2);
            CharValue += (HorseArchery * 2);

            CharValue += OneHandedWeapon;
            CharValue += TwoHandedWeapon;
            CharValue += Polearms;
            CharValue += Archery;
            CharValue += Crossbow;
            CharValue += Throwing;
        }

    } 
}
