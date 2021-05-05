#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public class InteractPanel : Panel
    {
        [SerializeField] private Typewriter typewriter;

        public override void Initialise()
        {
            
        }

        public void Bind(string text)
        {
            typewriter.Text = text;
            Debug.Log("Bind the target Interactable to the current window");
        }
    }
}
