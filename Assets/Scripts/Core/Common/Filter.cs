using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public struct Filter
    {
        private readonly HashSet<Type> _entities;

        public Filter(params Type[] typesOf)
        {
            _entities = new HashSet<Type>();

            for (int i = 0; i < typesOf.Length; i++)
            {
                _entities.Add(typesOf[i]);
            }
        }

        public bool Has(Type entity)
        {
            return _entities.Contains(entity);
        }
    }
}
