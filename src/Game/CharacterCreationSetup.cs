using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBUnity
{
    public class CharacterCreationSetup : MonoBehaviour
    {

        public Character player;

        // Use this for initialization
        void Awake()
        {
            player.Level = 1;
            player.Strength = 5;
            player.Agility = 5;
            player.Intelligence = 4;
            player.Charisma = 5;
            player.OneHandedWeapon = 23;
            player.TwoHandedWeapon = 15;
            player.Polearms = 25;
            player.Archery = 15;
            player.Crossbow = 15;
            player.Throwing = 15;

            player.Riding = 1;
            player.Leadership = 1;

            player.AttributePoints = 4;
            player.SkillPoints = 5;
            player.WeaponPoints = 10;

            player.Age = 0;
            player.Ironflesh = 0;
            player.PowerDraw = 0;
            player.PowerStrike = 0;
            player.PowerThrow = 0;
            player.WeaponMaster = 0;
            player.Shield = 0;
            player.Athletics = 0;
            player.HorseArchery = 0;
            player.Looting = 0;
            player.Tracking = 0;
            player.Trainer = 0;
            player.Tactics = 0;
            player.PathFinding = 0;
            player.Spotting = 0;
            player.InventoryManagement = 0;
            player.WoundTreatment = 0;
            player.Surgery = 0;
            player.FirstAid = 0;
            player.Engineer = 0;
            player.Persuasion = 0;
            player.PrisonerManagement = 0;
            player.Trade = 0;
            player.Honor = 0;
            player.Renown = 0;
        }

        // Update is called once per frame
        void Update()
        {

        }
    } 
}
