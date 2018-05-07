using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBUnity
{
    public class LocationSetup : MonoBehaviour
    {
        public Location LocationData;

        private TextMesh locationText;
        private GameObject obj;

        private void Start()
        {
            locationText = GetComponentInChildren<TextMesh>();

            locationText.text = LocationData.Name;
            locationText.color = LocationData.Ruler.FactionData.Color;
        }

    } 
}
