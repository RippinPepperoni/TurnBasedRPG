#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public class InteractPanelLayout : PanelLayout
    {
        [Header("Panels")]
        [SerializeField] private InteractPanel interactPanel;

        private Dialogue _dialogue;

        private void Awake()
        {
            Initialise();         
        }

        protected override void Initialise()
        {
            panels.Add(interactPanel);

            currentPanel = interactPanel;
        }

        public void Bind(Dialogue dialogue)
        {
            _dialogue = dialogue;
        }

        public bool Display(int index)
        {
            if (index < _dialogue.Sentences.Length)
            {
                string text = _dialogue.Sentences[index];

                interactPanel.Bind(text);

                return true;
            }

            return false;
        }
    }
}
