#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public class RandomEncounterSpawner : MonoBehaviour
    {
        [SerializeField] private MonsterEncounterSet monsterEncounterSet;
        [SerializeField] private Combatant monster;

        private void Awake()
        {
            var encounter = monsterEncounterSet.Get(Random.Range(0, monsterEncounterSet.Count));

            monster.gameObject.name = encounter.Name;

            monster.Sprite = encounter.Sprite;
            monster.Level = Random.Range(3, 8);

            monster.Affinity = Affinity.Hostile;

            monster.Health = new Attribute(monster.CalculateHealthAttributeValue(encounter.Health));
            monster.Attack = new Attribute(monster.CalculateAttributeValue(encounter.Attack));
            monster.Defence = new Attribute(monster.CalculateAttributeValue(encounter.Defence));
            monster.Speed = new Attribute(monster.CalculateAttributeValue(encounter.Speed));

            monster.Abilities = encounter.Abilities;
        }
    }
}
