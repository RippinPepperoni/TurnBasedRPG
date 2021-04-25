using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public static class App
    {
        private readonly static Dictionary<Filter, ISystem> _systems = new Dictionary<Filter, ISystem>();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Bootstrap()
        {
            Register(typeof(PersistantDataSystem));
        }

        private static void Register(params Type[] typesOf)
        {
            for (int i = 0; i < typesOf.Length; i++)
            {
                var instance = Activator.CreateInstance(typesOf[i]);

                if (instance is ISystem)
                {
                    var system = instance as ISystem;
                    system.Initialise();
                    _systems.Add(system.Filter, system);
                }
            }
        }

        public static void AddEntity(IEntity entity)
        {
            foreach (var filter in _systems.Keys)
            {
                if (filter.Has(entity.GetType()))
                {
                    _systems[filter].OnEntityAdded(entity);
                }
            }
        }

        public static void RemoveEntity(IEntity entity)
        {
            foreach (var filter in _systems.Keys)
            {
                if (filter.Has(entity.GetType()))
                {
                    _systems[filter].OnEntityRemoved(entity);
                }
            }
        }

        public static S GetSystem<S>()
        {
            var typeOf = typeof(S);

            foreach (var system in _systems.Values)
            {
                if (system.GetType() == typeOf)
                {
                    return (S)system;
                }
            }

            throw new Exception($"System of type {typeOf.Name} was not found, make sure the system is registered");
        }
    }
}
