using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TurnBasedRPG
{
    public class CombatBeginState<T> : State<T>
    {
        private readonly CombatSystem _combatSystem;

        public CombatBeginState(T uniqueID, CombatSystem combatSystem) : base(uniqueID)
        {
            _combatSystem = combatSystem;
        }

        public override void OnEnter()
        {
            _combatSystem.StartCoroutine(BeginCombat());
        }

        private IEnumerator BeginCombat()
        {
            var monster = _combatSystem.Monster;

            yield return _combatSystem.Typewriter.SetText($"", 0.125f);

            yield return Tween.MaterialDissolve.To(monster.GetComponent<Image>().material, 0f, 1f, Easing.Linear);

            yield return _combatSystem.Typewriter.SetText($"Encountered a {_combatSystem.Monster.Name}!", 1f);

            _combatSystem.ChangeState(CombatState.Wait);
        }
    }
}
