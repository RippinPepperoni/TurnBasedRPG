using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public abstract class EntitySystem : ISystem
    {
        public Filter Filter { get; protected set; }

        public bool IsEnabled { get; set; } = true;

        public virtual void Initialise()
        {
            
        }

        public virtual void OnEntityAdded(IEntity entity)
        {
            
        }

        public virtual void OnEntityRemoved(IEntity entity)
        {
            
        }

        public virtual void Dispose()
        {

        }
    }
}
