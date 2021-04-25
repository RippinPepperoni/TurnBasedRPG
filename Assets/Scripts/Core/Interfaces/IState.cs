using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public interface IState<T>
    {
        T UniqueID { get; }

        void OnEnter();
        void OnUpdate();
        void OnExit();
    }
}
