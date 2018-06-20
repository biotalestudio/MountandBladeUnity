using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MBUnity.Enums;

namespace MBUnity
{
    [CreateAssetMenu(menuName = "Game/Item/Armor", fileName = "New Armor")]
    public class Armor : Item
    {
        [Header("Armor")]
        public ArmorType Type;
    }
}
