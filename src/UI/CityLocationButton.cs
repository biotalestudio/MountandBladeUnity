using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBUnity
{
    public class CityLocationButton : MonoBehaviour
    {

        public enum ButtonType
        {
            GO_CASTLE,
            WALK_STREET,
            VISIT_TAVERN,
            ENTER_ARENA,
            GO_MARKETPLACE,
            WAIT,
            LEAVE
        }

        public LocationSceneUI locationSceneUI;

        public ButtonType button;

        private Party m_player;

        private void Awake()
        {
            /* An optimizied solution would be to set the variable's value in the editor */
            m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<PartyScript>().GetParty();
        }

        public bool CheckAvaib()
        {
            switch (button)
            {
                case ButtonType.GO_CASTLE:
                    if (/*Conditions*/true)
                        return true;
                    else
                        return false;
                    break;
                case ButtonType.WALK_STREET:
                    if (true)
                        return true;
                    else
                        return false;
                    break;
                case ButtonType.VISIT_TAVERN:
                    if (true)
                        return true;
                    else
                        return false;
                    break;
                case ButtonType.ENTER_ARENA:
                    if (true)
                        return true;
                    else
                        return false;
                    break;
                case ButtonType.GO_MARKETPLACE:
                    if (true)
                        return true;
                    else
                        return false;
                    break;
                case ButtonType.WAIT:
                    if (true)
                        return true;
                    else
                        return false;
                    break;
                case ButtonType.LEAVE:
                    if (true)
                        return true;
                    else
                        return false;
                    break;
                default:
                    return false;
            }
        }

        public void OnClick()
        {
            switch (button)
            {
                case ButtonType.WAIT:
                    m_player.script.EnterLocation(locationSceneUI.locationData);
                    break;
            }
        }
    }

}