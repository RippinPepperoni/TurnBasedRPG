using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public class ExploreState<T> : State<T>
    {
        private readonly InteractionSystem _interactionSystem;
        private readonly InteractPanelLayout _interactPanelLayout;

        private readonly SceneRuntimeSet _sceneRuntimeSet;

        private readonly InputSystem _inputSystem;
        private readonly SceneManagementSystem _sceneSystem;

        public ExploreState(T uniqueID, InteractionSystem interactionSystem) : base(uniqueID)
        {
            _interactionSystem = interactionSystem;

            _interactPanelLayout = _interactionSystem.InteractPanelLayout;
            _sceneRuntimeSet = _interactionSystem.SceneRuntimeSet;

            _inputSystem = App.GetSystem<InputSystem>();
            _sceneSystem = App.GetSystem<SceneManagementSystem>();
        }

        public override void OnEnter()
        {
            _interactPanelLayout.Hide();

            _inputSystem.SetActionMapEnabled(GameState.Explore.ToString());
            _inputSystem.SetActionMapDisabled(GameState.Interact.ToString());

            Interactable.OnInteract.AddHandler(OnInteractStarted);

            Debug.Log("Entered exploration state");
        }

        public override void OnUpdate()
        {
            SceneOverworldLoading();
        }

        private void SceneOverworldLoading()
        {
            for (int i = 0; i < _sceneRuntimeSet.Count; i++)
            {
                var context = _sceneRuntimeSet.Get(i);
                _sceneSystem.LoadSceneByDistance(context);
            }
        }

        private void OnInteractStarted(Interactable interactable)
        {
            _interactionSystem.Interactable = interactable;
            _interactionSystem.ChangeState(GameState.Interact);
        }

        public override void OnExit()
        {
            Interactable.OnInteract.RemoveHandler(OnInteractStarted);
        }
    }
}
