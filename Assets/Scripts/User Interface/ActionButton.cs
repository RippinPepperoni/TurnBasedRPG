#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TurnBasedRPG
{
    public class ActionButton : Button
    {
        [SerializeField] private Typewriter typewriter;

        [SerializeField] private string description;

        public override void OnSelect(BaseEventData eventData)
        {
            typewriter.Stop();
            typewriter.Text = description;
        }
    }
}
