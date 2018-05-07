using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBUnity
{
    public class VillageOptions : MonoBehaviour
    {
        public GameObject[] buttons;

        private void OnEnable()
        {

            foreach (GameObject button in buttons)
            {
                if (button.GetComponent<VillageLocationButton>().CheckForAvaib())
                {
                    button.SetActive(true);
                }
                else
                {
                    button.SetActive(false);
                }
            }
        }

        private void OnDisable()
        {
            foreach (GameObject button in buttons)
            {
                button.SetActive(false);
            }
        }
    } 
}
