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
            return Add(entity, out var component1, out var component2);
        }

        public bool Add(IEntity entity, out T1 component1, out T2 component2)
        {
            if (entity.HasComponent(out component1, out component2))
            {
                Add((component1, component2));
                return true;
            }

            return false;
        }

        public bool Remove(IEntity entity)
        {
            return Remove(entity, out var component1, out var component2);
        }

        public bool Remove(IEntity entity, out T1 component1, out T2 component2)
        {
            return entity.HasComponent(out component1, out component2) && Remove((component1, component2));
        }
    }
}