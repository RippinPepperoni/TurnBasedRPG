using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public enum PlayerState
    {
        Idle,
        Movement
    }

    public class Player : EntityComponent, IInput
    {
        public Vector2 Input { get; set; }
        public Vector2 Direction { get; set; }

        private StateMachine<PlayerState> _stateMachine;

        private readonly float _radius = 1f;

        private void Awake()
        {
            Create();
        }

        private void Create()
        {
            var stateList = new List<IState<PlayerState>>()
            {
                new PlayerIdleState<PlayerState>(PlayerState.Idle, this),
                new PlayerMovementState<PlayerState>(PlayerState.Movement, this)
            };

            _stateMachine = new StateMachine<PlayerState>(stateList.ToArray(), PlayerState.Idle);
            _stateMachine.OnEnter();
        }

        private void Update()
        {
            _stateMachine.OnUpdate();
        }

        public void ChangeState(PlayerState state)
        {
            _stateMachine.ChangeState(state);
        }

        public void Interact()
        {
            var hit = Physics2D.OverlapCircle(transform.position, _radius, 7 << 8);

            if (hit && hit.TryGetComponent(out Interactable component))
            {
                Interactable.OnInteract.Raise(component);
            }
        }
    }
}
