using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBUnity
{
    public class CityOptions : MonoBehaviour
    {
        public GameObject[] buttons;

        void OnEnable()
        {
            foreach (GameObject button in buttons)
            {
                if (button.GetComponent<CityLocationButton>().CheckAvaib())
                {
                    button.SetActive(true);
                }
                else
                {
                    button.SetActive(false);
                }
            }
        }

        void OnDisable()
        {
            foreach (GameObject button in buttons)
            {
                button.SetActive(false);
            }
        }
    }

}