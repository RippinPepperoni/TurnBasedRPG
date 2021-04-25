using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public struct Tweener<T, C> : IDisposable
    {
        public Func<C, T> GetValue { get; }
        public Action<C, T> SetValue { get; }

        public Tweener(Func<C, T> getValue, Action<C, T> setValue)
        {
            GetValue = getValue;
            SetValue = setValue;
        }

        public IEnumerator Update<I>(C context, T from, T to, float duration, bool reset, I interpolator) where I : IInterpolator<T>
        {
            float timeElapased = 0f;

            var defaultValue = GetValue(context);

            SetValue(context, interpolator.Interpolate(from, to, 0));

            while (timeElapased < duration)
            {
                yield return null;

                timeElapased += Time.deltaTime;
                SetValue(context, interpolator.Interpolate(from, to, Mathf.Min(timeElapased / duration, 1.0f)));
            }

            if (reset)
            {
                SetValue(context, defaultValue);
            }
        }

        public void Dispose()
        {
            
        }
    }
}
