#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public class CombatPanelLayout : PanelLayout
    {
        [Header("Bindings")]
        [SerializeField] private CombatSystem combatSystem;
        [SerializeField] private Combatant player;

        [Header("Panels")]
        [SerializeField] private ActionPanel actionPanel;
        [SerializeField] private AttackPanel attackPanel;

        private void Awake()
        {
            Initialise();
        }

        protected override void Initialise()
        {
            panels.Add(actionPanel);
            panels.Add(attackPanel);

            currentPanel = actionPanel;

            actionPanel.Initialise();
            attackPanel.Initialise();
        }

        private void OnEnable()
        {
            AddHandlers();
        }

        private void AddHandlers()
        {
            actionPanel.OnAttackClick.AddHandler(() => Change<AttackPanel>());
            actionPanel.OnTalkClick.AddHandler(() => combatSystem.OnTalkSelected());
            actionPanel.OnRunClick.AddHandler(() => GameController.Instance.Pop());

            attackPanel.OnAbilityOneClick.AddHandler(() => combatSystem.OnAbilitySelected(0));

            attackPanel.OnAbilityTwoClick.AddHandler(() => combatSystem.OnAbilitySelected(1));

            attackPanel.OnReturnClick.AddHandler(() => Change<ActionPanel>());
        }

        private void Start()
        {
            Bind();
        }

        private void Bind()
        {
            attackPanel.Bind(player);
        }

        private void OnDisable()
        {
            RemoveHandlers();
        }

        private void RemoveHandlers()
        {
            actionPanel.OnAttackClick.RemoveHandler(() => Change<AttackPanel>());
            actionPanel.OnTalkClick.RemoveHandler(() => combatSystem.OnTalkSelected());
            actionPanel.OnRunClick.RemoveHandler(() => GameController.Instance.Pop());

            attackPanel.OnAbilityOneClick.RemoveHandler(() => combatSystem.OnAbilitySelected(0));

            attackPanel.OnAbilityTwoClick.RemoveHandler(() => combatSystem.OnAbilitySelected(1));

            attackPanel.OnReturnClick.RemoveHandler(() => Change<ActionPanel>());
        }
    }
}
