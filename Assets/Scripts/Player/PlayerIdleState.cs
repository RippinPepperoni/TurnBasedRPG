using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public class PlayerIdleState<T> : State<T>
    {
        private readonly Player _player;

        public PlayerIdleState(T uniqueID, Player player) : base(uniqueID)
        {
            _player = player;
        }

        public override void OnUpdate()
        {
            if (!Mathf.Approximately(_player.Input.sqrMagnitude, 0f))
            {
                _player.ChangeState(PlayerState.Movement);
            }
        }
    }
}
