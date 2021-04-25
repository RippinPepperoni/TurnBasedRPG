using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    [CreateAssetMenu(fileName = "New AttributeSet", menuName = "ScriptableObjects/Abilities/AttributeSet")]
    public class AttributeSet : ScriptableObject
    {
        public string Name;

        public int Health;
        public int Attack;
        public int Defence;
        public int Speed;

        public Ability[] Abilities;
    }
}
