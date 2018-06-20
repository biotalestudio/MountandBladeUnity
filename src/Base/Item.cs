using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MBUnity.Enums;

namespace MBUnity
{
    [CreateAssetMenu(menuName = "Game/Item/TrollItem", fileName = "New Item")]
    public class Item : ScriptableObject
    {
        [Header("General Item")]
        public int Value;
        public int Weight;
        public string Name;
        public float SellPriceReduction;
        public GameObject Model;
        [Tooltip("Required for inventory screen")]
        public Sprite Sprite;
    }




}
