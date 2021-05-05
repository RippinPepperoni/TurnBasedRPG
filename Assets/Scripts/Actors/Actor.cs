#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public class Actor : Interactable
    {
        [SerializeField] private Dialogue dialogue;

        public override bool CanInteract()
        {
            return true;
        }

        public override object Interact()
        {
            return dialogue;
        }
    }
}
