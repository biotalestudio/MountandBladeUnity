using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MBUnity
{
    public class BottomUIPartyText : MonoBehaviour
    {

        public Party player;

        private Text m_text;
        // Use this for initialization
        void Start()
        {
            m_text = GetComponent<Text>();
            m_text.text = player.Size + " / " + player.Limit;
        }

        // Update is called once per frame
        void Update()
        {

        }
    } 
}
