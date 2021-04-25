using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace TurnBasedRPG
{
    [CreateAssetMenu(fileName = "New Damage Effect", menuName = "ScriptableObjects/Abilities/Effects/Damage")]
    public class Damage : Effect
    {
        private RectTransform _rectTransform;
        private Material _material;

        private const int duration = 1;
        private const int amplitude = 10;
        private const int strength = 2;

        public override bool CanApply(Ability ability, Combatant target, Combatant instigator)
        {
            base.CanApply(ability, target, instigator);

            if (target.Affinity == Affinity.Hostile)
            {
                _rectTransform = target.GetComponent<RectTransform>();
                _material = target.GetComponent<Image>().material;
            }

            return true;
        }

        public override IEnumerator Apply()
        {
            float seed = Random.Range(0.85f, 1f);

            float damage = Mathf.Floor(((2f * instigator.Level / 5f + 2f) * ability.Power * instigator.Attack.Value / instigator.Defence.Value / 50f + 2f) * seed);

            target.Health.Decrease(damage);

            if (target.Affinity == Affinity.Hostile)
            {
                yield return Tween.AnchoredPosition.Shake(_rectTransform, duration, amplitude, strength);

                yield return Tween.MaterialAlpha.To(_material, 0f, duration / 4f, Easing.PingPong);
                yield return Tween.MaterialAlpha.To(_material, 0f, duration / 4f, Easing.PingPong);
                yield return Tween.MaterialAlpha.To(_material, 0f, duration / 4f, Easing.PingPong);
            }

            yield return new WaitForSeconds(duration);
        }

    }
}
