using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public class CombatLostState<T> : State<T>
    {
        public CombatLostState(T uniqueID) : base(uniqueID)
        {

        }

        public override void OnEnter()
        {
            GameController.Instance.Pop();
        }
    }
}
