#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TurnBasedRPG
{
    public class AttackPanel : Panel
    {
        public Event OnAbilityOneClick { get; } = new Event();
        public Event OnAbilityTwoClick { get; } = new Event();

        public Event OnReturnClick { get; } = new Event();

        [SerializeField] private AbilityButton abilityButtonOne;
        [SerializeField] private AbilityButton abilityButtonTwo;

        [SerializeField] private ActionButton returnButton;

        private AbilityButton[] abilityButtons;

        private const int maxNumberOfAbilities = 2;

        public override void Initialise()
        {
            abilityButtons = new AbilityButton[maxNumberOfAbilities] { abilityButtonOne, abilityButtonTwo };

            AddListeners();
        }

        private void AddListeners()
        {
            abilityButtonOne.onClick.AddListener(() => OnAbilityOneClick.Raise());
            abilityButtonTwo.onClick.AddListener(() => OnAbilityTwoClick.Raise());

            returnButton.onClick.AddListener(() => OnReturnClick.Raise());
        }

        public void Bind(Combatant combatant)
        {
            var abilities = combatant.Abilities;
            int length = abilities.Length;

            for (int i = 0; i < maxNumberOfAbilities; i++)
            {
                if (length > i)
                {
                    abilityButtons[i].Activate(abilities[i]);
                }
                else
                {
                    abilityButtons[i].Deactivate();
                }
            }
        }

        public override void Show()
        {
            base.Show();

            abilityButtonOne.Select();
        }

        private void OnDestroy()
        {
            abilityButtonOne.onClick.RemoveAllListeners();
            abilityButtonTwo.onClick.RemoveAllListeners();

            returnButton.onClick.RemoveAllListeners();
        }
    }
}
