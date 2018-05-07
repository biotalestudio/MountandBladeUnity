using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MBUnity
{
    public class VillageLocationButton : MonoBehaviour
    {
        public LocationSceneUI locationSceneUI;

        public enum ButtonType
        {
            RECRUIT_VOLUNTEERS,
            GO_VILLAGE_CENTER,
            BUY_FROM_PEASANTS,
            TAKE_HOSTILE_ACTION,
            LEAVE
        }

        public ButtonType button;

        public bool CheckForAvaib()
        {
            switch (button)
            {
                case ButtonType.RECRUIT_VOLUNTEERS:
                    if (locationSceneUI.locationData.Type == Enums.LocationType.Village && /* Some other conditions */ true)
                    {
                        return true;
                    }
                    else
                        return false;
                    break;
                case ButtonType.GO_VILLAGE_CENTER:
                    if (locationSceneUI.locationData.Type == Enums.LocationType.Village)
                        return true;
                    else
                        return false;
                    break;
                case ButtonType.BUY_FROM_PEASANTS:
                    if (true)
                        return true;
                    else
                        return false;
                    break;
                case ButtonType.TAKE_HOSTILE_ACTION:
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
                    break;
            }
        }
    }

}