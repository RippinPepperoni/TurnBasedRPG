using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public interface IGameMode
    {
        string SceneName { get; }

        void OnEnter();
        void OnExit();
    }
}
