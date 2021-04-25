using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public class CombatExecuteState<T> : State<T>
    {
        private readonly CombatSystem _combatSystem;

        public CombatExecuteState(T uniqueID, CombatSystem combatSystem) : base(uniqueID)
        {
            _combatSystem = combatSystem;
        }

        public override void OnEnter()
        {
            _combatSystem.StartCoroutine(ExecuteActions());
        }

        private IEnumerator ExecuteActions()
        {
            _combatSystem.Typewriter.Stop();

            for (int i = 0; i < _combatSystem.Actions.Count; i++)
            {
                var action = _combatSystem.Actions[i];

                yield return action.Execute();

                if (DetermineActionType(action))
                {
                    yield break;
                }
            }

            _combatSystem.ChangeState(CombatState.Wait);
        }

        private bool DetermineActionType(IAction action)
        {
            if (action.GetType() == typeof(Attack))
            {
                var instance = action as Attack;
                var target = instance.Target;

                if (target.Health.Value <= 0)
                {
                    DetermineNextState(target);

                    return true;
                }
            }

            return false;
        }

        private void DetermineNextState(Combatant combatant)
        {
            if (combatant.Affinity == Affinity.Friendly)
            {
                _combatSystem.ChangeState(CombatState.Lost);
            }
            else if (combatant.Affinity == Affinity.Hostile)
            {
                _combatSystem.ChangeState(CombatState.Won);
            }
        }

        public override void OnExit()
        {
            _combatSystem.Actions.Clear();
        }
    }
}
