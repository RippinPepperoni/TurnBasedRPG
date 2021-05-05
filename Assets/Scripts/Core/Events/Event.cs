using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public class Event
    {
        private readonly List<Action> _handlers;

        public Event()
        {
            _handlers = new List<Action>();
        }

        public Event(Action handler) : this()
        {
            AddHandler(handler);
        }

        public void AddHandler(Action handler)
        {
            _handlers.Add(handler);
        }

        public void RemoveHandler(Action hanlder)
        {
            _handlers.Remove(hanlder);
        }

        public void Raise()
        {
            for (int i = 0; i < _handlers.Count; i++)
            {
                _handlers[i]?.Invoke();
            }
        }
    }

    public class Event<T>
    {
        private readonly List<Action<T>> _handlers;

        public Event()
        {
            _handlers = new List<Action<T>>();
        }

        public void AddHandler(Action<T> handler)
        {
            _handlers.Add(handler);
        }

        public void RemoveHandler(Action<T> hanlder)
        {
            _handlers.Remove(hanlder);
        }

        public void Raise(T args)
        {
            for (int i = 0; i < _handlers.Count; i++)
            {
                _handlers[i]?.Invoke(args);
            }
        }
    }
}
