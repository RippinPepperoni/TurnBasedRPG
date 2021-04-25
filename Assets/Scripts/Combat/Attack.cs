using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public class Attack : IAction, IComparable
    {
        public Combatant Target { get; }
        public Combatant Instigator { get; }

        private readonly Ability _ability;
        private readonly CombatSystem _combatSystem;

        private WaitForSeconds _delay = new WaitForSeconds(1f);

        public Attack(Ability ability, CombatSystem combatSystem, Combatant target, Combatant instigator)
        {
            _ability = ability;
            _combatSystem = combatSystem;

            Target = target;
            Instigator = instigator;
        }

        public IEnumerator Execute()
        {
            yield return _combatSystem.Typewriter.SetText($"{Instigator.Name} used {_ability.Name}!");

            yield return _ability.Execute(Target, Instigator);

            yield return _combatSystem.Typewriter.SetText($"{Target.Name} has {Target.Health.Value}HP remaining!", 1f);
        }

        public int CompareTo(object obj)
        {
            return 1;
        }
    }
}
