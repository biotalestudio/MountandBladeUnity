using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MBUnity.Enums;

namespace MBUnity
{
    [CreateAssetMenu(menuName = "Game/Item/Weapon", fileName = "New Weapon")]
    public class Weapon : Item
    {
        [Header("Weapon")]
        public int Damage;
        public WeaponType Type;
    }
}
