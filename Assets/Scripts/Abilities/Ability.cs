#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace TurnBasedRPG
{
    [CreateAssetMenu(fileName = "New Ability", menuName = "ScriptableObjects/Abilities/Ability")]
    public class Ability : ScriptableObject
    {
        [SerializeField] public string Name;
        [SerializeField] public string Description;

        [SerializeField] public float Power;

        [SerializeField] private Effect effect;

        public IEnumerator Execute(Combatant target, Combatant instigator)
        {
            if (effect.CanApply(this, target, instigator))
            {
                yield return effect.Apply();
            }
        }
    }
}
