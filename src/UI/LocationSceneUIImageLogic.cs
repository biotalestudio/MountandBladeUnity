using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MBUnity
{
    public class LocationSceneUIImageLogic : MonoBehaviour
    {

        public LocationSceneUI LocationScene;

        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        private void OnEnable()
        {
            switch (LocationScene.locationData.Type)
            {
                case Enums.LocationType.Village:
                    _image.sprite = LocationScene.villageImage01;
                    break;
                case Enums.LocationType.City:
                    _image.sprite = LocationScene.cityImage01;
                    break;
            }
        }
    } 
}
