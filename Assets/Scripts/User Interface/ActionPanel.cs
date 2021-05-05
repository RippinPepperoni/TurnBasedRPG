#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TurnBasedRPG
{
    public class ActionPanel : Panel
    {
        public Event OnAttackClick { get; } = new Event();
        public Event OnTalkClick { get; } = new Event();
        public Event OnRunClick { get; } = new Event();

        [SerializeField] private Button attackButton;
        [SerializeField] private Button talkButton;
        [SerializeField] private Button runButton;

        public override void Initialise()
        {
            AddListeners();
        }

        private void AddListeners()
        {
            attackButton.onClick.AddListener(() => OnAttackClick.Raise());
            talkButton.onClick.AddListener(() => OnTalkClick.Raise());
            runButton.onClick.AddListener(() => OnRunClick.Raise());
        }

        public override void Show()
        {
            base.Show();

            attackButton.Select();
        }

        private void OnDestroy()
        {
            attackButton.onClick.RemoveAllListeners();
            talkButton.onClick.RemoveAllListeners();
            runButton.onClick.RemoveAllListeners();
        }
    }
}
