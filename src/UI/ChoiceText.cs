using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MBUnity
{
    public class ChoiceText : MonoBehaviour
    {

        public string[] choiceTexts;
        [HideInInspector]
        public int choiceNumber;

        Text m_Text;



        // Use this for initialization
        void Awake()
        {
            m_Text = GetComponent<Text>();
        }

        private void OnEnable()
        {
            m_Text.text = choiceTexts[choiceNumber];

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}