using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public class PlayerMovementState<T> : State<T>
    {
        private readonly Player _player;

        private const float speed = 4.25f;

        public PlayerMovementState(T uniqueID, Player player) : base(uniqueID)
        {
            _player = player;
        }

        public override void OnUpdate()
        {
            if (Mathf.Approximately(_player.Input.sqrMagnitude, 0f))
            {
                _player.ChangeState(PlayerState.Idle);
            }

            _player.transform.position += new Vector3(_player.Input.x, _player.Input.y, 0f) * Time.deltaTime * speed;
        }
    }
}
