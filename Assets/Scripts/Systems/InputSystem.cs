using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TurnBasedRPG
{
    public class InputSystem : EntitySystem
    {
        private readonly PlayerInputActions _inputActions = new PlayerInputActions();

        private Player _player;

        public override void Initialise()
        {
            Filter = new Filter(typeof(Player));

            _inputActions.Enable();

            _inputActions.Explore.Move.performed += ctx => OnMove(ctx.ReadValue<Vector2>());
            _inputActions.Explore.Interact.performed += ctx => OnInteract();
        }

        public override void OnEntityAdded(IEntity entity)
        {
            _player = entity as Player;
        }

        private void OnMove(Vector2 value)
        {
            if (value.y != 0f)
            {
                value.x = 0f;
            }

            _player.Input = value;

            if (value.sqrMagnitude != 0f)
            {
                _player.Direction = value;
            }
        }

        private void OnInteract()
        {
            _player.Interact();
        }

        public override void OnEntityRemoved(IEntity entity)
        {
            _player = null;
        }

        public void SetActionMapEnabled(string map)
        {
            _inputActions.asset.FindActionMap(map).Enable();
        }

        public void SetActionMapDisabled(string map)
        {
            _inputActions.asset.FindActionMap(map).Disable();

            OnMove(Vector2.zero);
        }

        public override void Dispose()
        {
            _inputActions.Explore.Move.performed -= ctx => OnMove(ctx.ReadValue<Vector2>());
            _inputActions.Explore.Interact.performed -= ctx => OnInteract();

            _inputActions.Disable();
        }
    }
}
