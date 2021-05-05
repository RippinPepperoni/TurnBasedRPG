using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    [CreateAssetMenu(fileName = "New Game Event", menuName = "ScriptableObjects/Events/Game Event")]
    public class GameEvent : ScriptableObject
    {
        public delegate void Handler();
        private Handler _handlers;

        public void Register(Handler handler)
        {
            _handlers += handler;
        }

        public void Unregister(Handler handler)
        {
            _handlers -= handler;
        }

        public void Raise()
        {
            _handlers?.Invoke();
        }
    }
}
