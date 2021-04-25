using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TurnBasedRPG
{
    public class CombatWonState<T> : State<T>
    {
        private readonly CombatSystem _combatSystem;
        private readonly CombatPanelLayout _combatPanelLayout;

        public CombatWonState(T uniqueID, CombatSystem combatSystem) : base(uniqueID)
        {
            _combatSystem = combatSystem;
            _combatPanelLayout = combatSystem.CombatPanelLayout;
        }

        public override void OnEnter()
        {
            _combatPanelLayout.Hide();
            _combatSystem.StartCoroutine(DissolveMonster());
        }

        private IEnumerator DissolveMonster()
        {
            var monster = _combatSystem.Monster;

            yield return Tween.MaterialDissolve.To(monster.GetComponent<Image>().material, 1f, 1f, Easing.Linear);

            yield return _combatSystem.Typewriter.SetText($"{monster.Name} has been defeated!", 0.5f);

            yield return _combatSystem.Typewriter.SetText($"", 0.1f);

            GameController.Instance.Pop();
        }
    }
}
