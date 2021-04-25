using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public interface IInterpolator<T>
    {
        T Interpolate(T from, T to, float time);
    }

    public struct FloatInterpolator : IInterpolator<float>
    {
        private readonly Func<float, float> _easing;

        public FloatInterpolator(Func<float, float> easing)
        {
            _easing = easing;
        }

        public float Interpolate(float from, float to, float time)
        {
            return Mathf.LerpUnclamped(from, to, _easing(time));
        }
    }

    public struct Vector3Interpolator : IInterpolator<Vector3>
    {
        private readonly Func<float, float> _easing;

        public Vector3Interpolator(Func<float, float> easing)
        {
            _easing = easing;
        }

        public Vector3 Interpolate(Vector3 from, Vector3 to, float time)
        {
            return new Vector3(Mathf.LerpUnclamped(from.x, to.x, _easing(time)), Mathf.LerpUnclamped(from.y, to.y, _easing(time)));
        }
    }

    public struct  ShakeInterpolator : IInterpolator<Vector3>
    {
        private readonly float _strength;

        public ShakeInterpolator(float strength)
        {
            _strength = strength;
        }

        public Vector3 Interpolate(Vector3 from, Vector3 to, float time)
        {
            return from + new Vector3(Mathf.PerlinNoise(0f, time * to.x) * 2f - 1f, Mathf.PerlinNoise(1f, time * to.y) * 2f - 1f) * _strength;
        }
    }
}
