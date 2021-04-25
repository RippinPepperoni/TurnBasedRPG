using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace TurnBasedRPG
{
    public abstract class Effect : ScriptableObject
    {
        protected Ability ability;

        protected Combatant target;
        protected Combatant instigator;

        public virtual bool CanApply(Ability ability, Combatant target, Combatant instigator)
        {
            this.ability = ability;

            this.target = target;
            this.instigator = instigator;

            return true;
        }

        public virtual IEnumerator Apply()
        {
            yield break;
        }

    }
}
