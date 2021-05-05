using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "ScriptableObjects/Interactable/Dialogue")]
    public class Dialogue : ScriptableObject
    {
        public string Name;
        public string[] Sentences;       
    }
}
