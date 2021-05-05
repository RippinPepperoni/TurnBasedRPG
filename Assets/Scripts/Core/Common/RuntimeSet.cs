using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public abstract class RuntimeSet<T> : ScriptableObject
    {
        [SerializeField] protected List<T> items = new List<T>();

        public int Count => items.Count;

        public T Get(int index) => items[index];

        public void Add(T item) => items.Add(item);

        public void Remove(T item) => items.Remove(item);

        public void Clear() => items.Clear();
    }
}
