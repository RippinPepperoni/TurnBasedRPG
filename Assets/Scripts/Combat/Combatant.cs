using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public enum Affinity
    {
        Friendly,
        Hostile
    }

    public class Combatant : EntityComponent
    {
        public Affinity Affinity { get; set; }

        public string Name => gameObject.name;

        public int Level { get; set; } = 5;

        public Sprite Sprite { get; set; }

        public Attribute Health { get; set; }
        public Attribute Attack { get; set; }
        public Attribute Defence { get; set; }
        public Attribute Speed { get; set; }

        public Ability[] Abilities { get; set; }

        public float CalculateHealthAttributeValue(int value)
        {
            return Mathf.Floor((value + Random.Range(0f, 31f)) * 2f * Level / 100f + Level + 10f);
        }

        public float CalculateAttributeValue(int value)
        {
            return Mathf.Floor((value + Random.Range(0f, 31f)) * 2f * Level / 100f + 5f);
        }
    }
}
