using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MBUnity
{
    public class LocationSceneUI : MonoBehaviour
    {
        public Location locationData;

        [Header("City Images")]
        public Sprite cityImage01;
        public Sprite cityImage02;
        public Sprite cityImage03;

        [Header("Castle Images")]
        public Sprite castleImage01;
        public Sprite castleImage02;
        public Sprite castleImage03;

        [Header("Village Images")]
        public Sprite villageImage01;
        public Sprite villageImage02;
        public Sprite villageImage03;

        [Header("Options")]
        public GameObject cityOption;
        public GameObject castleOption;
        public GameObject villageOption;

        public GameObject[] buttonObjects;

        [Header("UI Objects")]
        public GameObject backgroundImage;
        public GameObject text;
        public GameObject locationImage;

        // Use this for initialization
        void Awake()
        {

        }

        //Activates all UI elements, background image, text, options
        void ActivateUI()
        {
            backgroundImage.SetActive(true);
            text.SetActive(true);
            locationImage.SetActive(true);

            switch (locationData.Type)
            {
                case Enums.LocationType.City:
                    cityOption.SetActive(true);
                    break;
                case Enums.LocationType.Castle:
                    castleOption.SetActive(true);
                    break;
                case Enums.LocationType.Village:
                    villageOption.SetActive(true);
                    break;
            }

        }

        private void OnEnable()
        {
            ActivateUI();
        }

        private void OnDisable()
        {
            cityOption.SetActive(false);
            castleOption.SetActive(false);
            villageOption.SetActive(false);
            backgroundImage.SetActive(false);
            text.SetActive(false);
            locationImage.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}