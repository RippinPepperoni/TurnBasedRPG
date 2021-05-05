using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public class SystemComponents<T> : List<T>
    {
        public bool Add(IEntity entity)
        {
            return Add(entity, out var component);
        }

        public bool Add(IEntity entity, out T component)
        {
            if (entity.HasComponent(out component))
            {
                Add(component);
                return true;
            }

            return false;
        }

        public bool Remove(IEntity entity)
        {
            return Remove(entity, out var component);
        }

        public bool Remove(IEntity entity, out T component)
        {
            return entity.HasComponent(out component) && Remove(component);
        }
    }

    public class SystemComponents<T1, T2> : List<(T1, T2)>
    {
        public bool Add(IEntity entity)
        {
            return Add(entity, out var componentOne, out var componentTwo);
        }

        public bool Add(IEntity entity, out T1 componentOne, out T2 componentTwo)
        {
            if (entity.HasComponent(out componentOne, out componentTwo))
            {
                Add((componentOne, componentTwo));
                return true;
            }

            return false;
        }

        public bool Remove(IEntity entity)
        {
            return Remove(entity, out var componentOne, out var componentTwo);
        }

        public bool Remove(IEntity entity, out T1 componentOne, out T2 componentTwo)
        {
            return entity.HasComponent(out componentOne, out componentTwo) && Remove((componentOne, componentTwo));
        }
    }
}