#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public enum GameState
    {
        Explore,
        Interact
    }

    public class InteractionSystem : MonoBehaviour
    {
        [SerializeField] public SceneRuntimeSet SceneRuntimeSet;
        [SerializeField] public InteractPanelLayout InteractPanelLayout;

        public Interactable Interactable { get; set; }

        private StateMachine<GameState> _stateMachine;

        private void Awake()
        {
            Create();
        }

        private void Create()
        {
            var stateList = new List<IState<GameState>>()
            {
                new ExploreState<GameState>(GameState.Explore, this),
                new InteractState<GameState>(GameState.Interact, this)
            };

            _stateMachine = new StateMachine<GameState>(stateList.ToArray(), GameState.Explore);
        }

        private void Start()
        {
            _stateMachine.OnEnter();
        }

        private void Update()
        {
            _stateMachine.OnUpdate();
        }

        public void ChangeState(GameState state)
        {
            _stateMachine.ChangeState(state);
        }

        public void OnInteractStart()
        {
            ChangeState(GameState.Interact);
        }

        private void OnDestroy()
        {
            _stateMachine.Dispose();
        }
    }
}
