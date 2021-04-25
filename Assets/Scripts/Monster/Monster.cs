using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    [CreateAssetMenu(fileName = "New Monster", menuName = "ScriptableObjects/Monster/Monster")]
    public class Monster : AttributeSet
    {
        public Sprite Sprite;
    }
}
