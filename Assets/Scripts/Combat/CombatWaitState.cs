using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public class CombatWaitState<T> : State<T>
    {
        private readonly CombatSystem _combatSystem;
        private readonly CombatPanelLayout _combatPanelLayout;

        public CombatWaitState(T uniqueID, CombatSystem combatSystem) : base(uniqueID)
        {
            _combatSystem = combatSystem;
            _combatPanelLayout = combatSystem.CombatPanelLayout;
        }

        public override void OnEnter()
        {
            _combatPanelLayout.Change<ActionPanel>();
        }

        public override void OnExit()
        {
            _combatPanelLayout.Hide();
        }
    }
}
