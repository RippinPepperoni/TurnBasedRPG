using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public class InteractState<T> : State<T>
    {
        private readonly InteractionSystem _interactionSystem;
        private readonly InteractPanelLayout _interactPanelLayout;

        private readonly InputSystem _inputSystem;

        private int _index;

        public InteractState(T uniqueID, InteractionSystem interactionSystem) : base(uniqueID)
        {
            _interactionSystem = interactionSystem;
            _interactPanelLayout = _interactionSystem.InteractPanelLayout;

            _inputSystem = App.GetSystem<InputSystem>();
        }

        public override void OnEnter()
        {
            _inputSystem.SetActionMapDisabled(GameState.Explore.ToString());
            _inputSystem.SetActionMapEnabled(GameState.Interact.ToString());

            Debug.Log("Entered interaction state");

            Bind();
        }

        private void Bind()
        {
            var interactable = _interactionSystem.Interactable;

            if (interactable.CanInteract())
            {
                var content = interactable.Interact() as Dialogue;

                _interactPanelLayout.Bind(content);
                _interactPanelLayout.Show();
            }

            _index = 0;
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DisplayInteractionText();
            }
        }

        private void DisplayInteractionText()
        {
            if (!_interactPanelLayout.Display(_index))
            {
                _interactionSystem.ChangeState(GameState.Explore);
            }

            _index++;
        }
    }
}
