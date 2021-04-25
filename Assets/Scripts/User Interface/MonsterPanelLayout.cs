#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public class MonsterPanelLayout : PanelLayout
    {
        [Header("Bindings")]
        [SerializeField] private Combatant monster;

        [Header("Panels")]
        [SerializeField] private MonsterPanel monsterPanel;

        private void Awake()
        {
            Initialise();
        }

        protected override void Initialise()
        {
            panels.Add(monsterPanel);

            currentPanel = monsterPanel;

            monsterPanel.Bind(monster);
        }

        private void Start()
        {
            currentPanel.Show();
        }
    }
}
