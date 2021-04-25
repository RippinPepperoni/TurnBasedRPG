using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public abstract class EntityComponent : MonoBehaviour, IEntity
    {
        private void OnEnable()
        {
            App.AddEntity(this);
        }

        public bool HasComponent<T>(out T component)
        {
            return TryGetComponent(out component);
        }

        public bool HasComponent<T1, T2>(out T1 componentOne, out T2 componentTwo)
        {
            componentOne = default;
            componentTwo = default;

            return HasComponent(out componentOne) && HasComponent(out componentTwo);
        }

        private void OnDisable()
        {
            App.RemoveEntity(this);
        }
    }
}
