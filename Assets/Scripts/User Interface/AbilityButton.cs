#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TurnBasedRPG
{
    public class AbilityButton : Button
    {
        [SerializeField] private Typewriter typewriter;
        [SerializeField] private Text textComponent;

        private Ability _ability;

        private const string noValidAbility = "-";

        public void Activate(Ability ability)
        {
            _ability = ability;

            interactable = true;
            textComponent.text = _ability.Name;
        }

        public void Deactivate()
        {
            interactable = false;
            textComponent.text = noValidAbility;
        }

        public override void OnSelect(BaseEventData eventData)
        {
            typewriter.Stop();
            typewriter.Text = _ability.Description;  
        }
    }
}
