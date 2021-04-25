using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public interface ISystem
    {
        Filter Filter { get; }

        bool IsEnabled { get; set; }

        void Initialise();
        void OnEntityAdded(IEntity entity);
        void OnEntityRemoved(IEntity entity);
        void Dispose();
    }
}
