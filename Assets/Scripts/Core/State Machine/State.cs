using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public abstract class State<T> : IState<T>
    {
        public T UniqueID { get; }

        public State(T uniqueID)
        {
            UniqueID = uniqueID;
        }

        public virtual void OnEnter()
        {

        }

        public virtual void OnUpdate()
        {

        }

        public virtual void OnExit()
        {

        }
    }
}