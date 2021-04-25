using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public class Attribute
    {
        public float Value { get; private set; }
        public float MaxValue { get; private set; }

        public Attribute(float value)
        {
            Value = value;
            MaxValue = value;
        }

        public void Increase(float amount)
        {
            Value = Mathf.Min(Value + amount, MaxValue);
        }

        public void Decrease(float amount)
        {
            Value = Mathf.Max(Value - amount, 0f);
        }
    }
}
