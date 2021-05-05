#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TurnBasedRPG
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEvent gameEvent;
        [SerializeField] private UnityEvent response;

        private void OnEnable()
        {
            gameEvent.Register(OnRaise);
        }

        private void OnRaise()
        {
            response?.Invoke();
        }

        private void OnDisable()
        {
            gameEvent.Unregister(OnRaise);
        }
    }
}
