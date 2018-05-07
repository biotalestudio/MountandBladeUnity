using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MBUnity
{
    public class SquireTextChange : MonoBehaviour
    {

        public Character player;

        Text m_text;

        // Use this for initialization
        void Start()
        {

            m_text = GetComponent<Text>();

            if (player.CharacterSex == Character.Sex.MALE)
                m_text.text = "A squire";
            else
                m_text.text = "A lady in waiting";

        }

        // Update is called once per frame
        void Update()
        {

        }
    } 
}
