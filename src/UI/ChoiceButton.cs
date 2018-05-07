using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MBUnity
{
    public class ChoiceButton : MonoBehaviour
    {

        public static int[] Choices;
        public static bool IsInitilazied = false;

        public GameObject textObject;
        public Character player;
        public int creationStage;
        public int choiceNumber;

        public bool shouldChangeNextText;


        ChoiceText m_nextText;

        public static void Init()
        {
            Choices = new int[5];
            IsInitilazied = true;
        }

        private void Awake()
        {
            if (!IsInitilazied)
                Init();

        }



        public void RegisterChoice()
        {
            Choices[creationStage] = choiceNumber;
            if (shouldChangeNextText)
                SetChoiceNumber(choiceNumber);
        }

        //public void RegisterChoice(int t, int a)
        //{

        //}

        //public void Lol()
        //{

        //}

        public void SetChoiceNumber(int choice)
        {
            m_nextText = textObject.GetComponent<ChoiceText>();
            m_nextText.choiceNumber = choice;
        }

        public void ApplyStats()
        {
            for (int i = 0; i < Choices.Length; i++)
            {
                switch (i)
                {
                    //Sex Choice
                    case 0:
                        switch (Choices[i])
                        {
                            case 0:
                                player.CharacterSex = Character.Sex.MALE;
                                player.Strength++;
                                player.Charisma++;
                                break;
                            case 1:
                                player.CharacterSex = Character.Sex.FEMALE;
                                player.Agility++;
                                player.Intelligence++;
                                break;
                        }
                        break;
                    //Father Choice
                    case 1:
                        switch (Choices[i])
                        {
                            //Noble Choice
                            case 0:
                                player.Intelligence++;
                                player.Charisma++;
                                player.Agility++;
                                player.Riding++;
                                player.Leadership++;
                                player.OneHandedWeapon += 2;
                                player.Polearms += 7;
                                player.Renown += 50;
                                //Unfinisheedd
                                if (player.CharacterSex == Character.Sex.MALE)
                                {
                                    player.Charisma++;
                                    player.PowerStrike++;
                                    player.WeaponMaster++;
                                    player.Tactics++;
                                    player.TwoHandedWeapon += 15;
                                    player.Polearms += 14;
                                    player.Renown += 50;
                                    player.Honor += 3;
                                }
                                else if (player.CharacterSex == Character.Sex.FEMALE)
                                {
                                    player.Intelligence++;
                                    player.Riding++;
                                    player.WoundTreatment++;
                                    player.FirstAid++;
                                    player.OneHandedWeapon += 12;
                                    player.Polearms += 7;
                                }
                                break;
                            //Merchant Choice
                            case 1:
                                player.Intelligence += 2;
                                player.Charisma++;
                                player.Riding++;
                                player.InventoryManagement++;
                                player.Leadership++;
                                player.Trade += 2;
                                player.TwoHandedWeapon += 15;
                                player.Polearms += 7;
                                player.Renown += 20;
                                //Unfinished
                                break;
                            //Warrior Choice
                            case 2:
                                player.Strength++;
                                player.Agility++;
                                player.Charisma++;
                                player.Ironflesh++;
                                player.PowerStrike++;
                                player.WeaponMaster++;
                                player.Trainer++;
                                player.Leadership++;
                                player.OneHandedWeapon += 2;
                                player.TwoHandedWeapon += 23;
                                player.Polearms += 33;
                                player.Throwing += 15;
                                break;
                            //Hunter Choice
                            case 3:
                                player.Strength++;
                                player.Agility += 2;
                                player.PowerDraw++;
                                player.Athletics++;
                                player.Tracking++;
                                player.PathFinding++;
                                player.Spotting++;
                                player.TwoHandedWeapon += 15;
                                player.Polearms += 7;
                                player.Archery += 49;
                                //Unfinished
                                break;
                            //Nomad Choice
                            case 4:
                                player.Strength++;
                                player.Agility++;
                                player.Intelligence++;
                                player.Riding += 2;
                                player.PathFinding++;
                                player.OneHandedWeapon += 2;
                                player.Polearms += 7;
                                player.Archery += 32;
                                player.Throwing += 7;
                                player.Renown += 10;
                                if (player.CharacterSex == Character.Sex.MALE)
                                {
                                    player.PowerDraw++;
                                    player.HorseArchery++;
                                    player.Archery += 17;
                                    player.Throwing += 8;
                                    player.Renown += 10;
                                }
                                else if (player.CharacterSex == Character.Sex.FEMALE)
                                {
                                    player.WoundTreatment++;
                                    player.FirstAid++;
                                    player.OneHandedWeapon += 3;
                                    player.Renown += 10;
                                    //Unfinished
                                }
                                break;
                            //Thief Choice
                            case 5:
                                player.Agility += 3;
                                player.PowerThrow++;
                                player.Athletics += 2;
                                player.Looting++;
                                player.InventoryManagement++;
                                player.OneHandedWeapon += 14;
                                player.Polearms += 7;
                                player.Throwing += 31;
                                //Unfisinhed
                                break;
                        }
                        break;
                    //Early Life Choice
                    case 2:
                        switch (Choices[i])
                        {
                            //Page
                            case 0:
                                player.Strength++;
                                player.Charisma++;
                                player.PowerStrike++;
                                player.Persuasion++;
                                player.OneHandedWeapon += 8;
                                player.Polearms += 3;
                                break;
                            //Apperentice
                            case 1:
                                player.Strength++;
                                player.Intelligence++;
                                player.Engineer++;
                                player.Trade++;
                                break;
                            //Assistant
                            case 2:
                                player.Intelligence++;
                                player.Charisma++;
                                player.InventoryManagement++;
                                player.Trade++;
                                break;
                            //Urchin
                            case 3:
                                player.Agility++;
                                player.Intelligence++;
                                player.Looting++;
                                player.Spotting++;
                                player.OneHandedWeapon += 8;
                                player.Throwing += 7;
                                break;
                            //steppe child
                            case 4:
                                player.Strength++;
                                player.Agility++;
                                player.PowerThrow++;
                                player.HorseArchery++;
                                player.Archery += 24;
                                player.Renown += 5;
                                break;
                        }
                        break;
                    //Adulthood
                    case 3:
                        switch (Choices[i])
                        {
                            //Squire or lady in waiting
                            case 0:
                                if (player.CharacterSex == Character.Sex.MALE)
                                {
                                    player.Strength++;
                                    player.Agility++;
                                    player.PowerStrike++;
                                    player.WeaponMaster++;
                                    player.Riding++;
                                    player.Leadership++;
                                    player.OneHandedWeapon += 23;
                                    player.TwoHandedWeapon += 38;
                                    player.Polearms += 22;
                                    player.Archery += 16;
                                    player.Crossbow += 16;
                                    player.Throwing += 14;

                                    //Equipment Things should come
                                }
                                else if (player.CharacterSex == Character.Sex.FEMALE)
                                {
                                    player.Intelligence++;
                                    player.Charisma++;
                                    player.Riding++;
                                    player.WoundTreatment++;
                                    player.Persuasion += 2;
                                    player.OneHandedWeapon += 8;
                                    player.Crossbow += 24;

                                    //Equipment things should come
                                }
                                break;
                            //Troubadour
                            case 1:
                                player.Charisma += 2;
                                player.WeaponMaster += 1;
                                player.PathFinding++;
                                player.Persuasion++;
                                player.Leadership++;
                                player.OneHandedWeapon += 19;
                                player.Crossbow += 16;

                                //Equipment things should come
                                break;
                            //Student
                            case 2:
                                player.Intelligence += 2;
                                player.WeaponMaster += 1;
                                player.WoundTreatment += 1;
                                player.Surgery += 1;
                                player.Persuasion += 1;
                                player.OneHandedWeapon += 15;
                                player.Crossbow += 32;

                                ///equioment things should come
                                break;
                            //Peddler
                            case 3:
                                player.Intelligence += 1;
                                player.Charisma += 1;
                                player.Riding += 1;
                                player.PathFinding += 1;
                                player.InventoryManagement += 1;
                                player.Trade += 1;
                                player.Polearms += 11;
                                break;
                            //Smith
                            case 4:
                                player.Strength += 1;
                                player.Intelligence += 1;
                                player.WeaponMaster += 1;
                                player.Tactics += 1;
                                player.Engineer += 1;
                                player.Trade += 1;
                                player.OneHandedWeapon += 11;

                                //Equipment things should come
                                break;
                            //Poacher
                            case 5:
                                player.Strength += 1;
                                player.Agility += 1;
                                player.PowerDraw += 1;
                                player.Athletics += 1;
                                player.Tracking += 1;
                                player.Spotting += 1;
                                player.Polearms += 7;
                                player.Archery += 57;

                                //Equipment things shoulddd comeee
                                break;
                        }
                        break;
                    //Reason for adventuring
                    case 4:
                        switch (Choices[i])
                        {
                            //Revenge
                            case 0:
                                player.Strength += 2;
                                player.PowerStrike += 1;
                                break;
                            //Loss
                            case 1:
                                player.Charisma += 2;
                                player.Ironflesh += 1;
                                break;
                            //Wanderlust
                            case 2:
                                player.Agility += 2;
                                player.PathFinding += 1;
                                break;
                            //Forced out
                            case 3:
                                player.Strength += 1;
                                player.Intelligence += 1;
                                player.WeaponMaster += 1;
                                break;
                            //Money
                            case 4:
                                player.Agility++;
                                player.Intelligence++;
                                player.Looting++;
                                break;
                        }
                        break;
                }
            }
        }

        int x = 5;


        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    } 
}
