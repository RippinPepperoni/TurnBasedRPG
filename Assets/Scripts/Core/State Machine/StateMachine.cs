using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public class StateMachine<T> : IDisposable where T : struct, IConvertible, IComparable, IFormattable
    {
        private readonly Dictionary<T, IState<T>> _states = new Dictionary<T, IState<T>>();
        private IState<T> _currentState => _states[_currentStateID];

        private T _currentStateID;

        public StateMachine(IState<T>[] states, T stateID)
        {
            Bind(states);

            _currentStateID = stateID;
        }

        private void Bind(IState<T>[] states)
        {
            foreach (var state in states)
            {
                _states.Add(state.UniqueID, state);
            }
        }

        public void OnEnter()
        {
            _currentState.OnEnter();
        }

        public void OnUpdate()
        {
            _currentState.OnUpdate();
        }

        public void ChangeState(T stateID)
        {
            if (_states.ContainsKey(stateID) && !stateID.Equals(_currentStateID))
            {
                _currentState.OnExit();
                _currentStateID = stateID;
                _currentState.OnEnter();
            }
        }

        public void Dispose()
        {
            _currentState.OnExit();
            _states.Clear();
        }
    }
}
