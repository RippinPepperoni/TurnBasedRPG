using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace TurnBasedRPG
{
    public static class Tween
    {
        public static IEnumerator To<C>(this Tweener<float, C> tweener, C context, float to, float duration, Func<float, float> easing)
        {
            return tweener.Update(context, tweener.GetValue(context), to, duration, false, new FloatInterpolator(easing));
        }

        public static IEnumerator ToOffset<C>(this Tweener<float, C> tweener, C context, float to, float duration, Func<float, float> easing)
        {
            return tweener.Update(context, tweener.GetValue(context), tweener.GetValue(context) + to, duration, false, new FloatInterpolator(easing));
        }



        public static IEnumerator To<C>(this Tweener<Vector3, C> tweener, C context, Vector3 to, float duration, Func<float, float> easing)
        {
            return tweener.Update(context, tweener.GetValue(context), to, duration, false, new Vector3Interpolator(easing));
        }

        public static IEnumerator ToOffset<C>(this Tweener<Vector3, C> tweener, C context, Vector3 to, float duration, Func<float, float> easing)
        {
            return tweener.Update(context, tweener.GetValue(context), tweener.GetValue(context) + to, duration, false, new Vector3Interpolator(easing));
        }

        public static IEnumerator Shake<C>(this Tweener<Vector3, C> tweener, C context, float duration, float amplitude, float strength)
        {
            return tweener.Update(context, tweener.GetValue(context), new Vector3(amplitude, amplitude), duration, true, new ShakeInterpolator(strength));
        }


        public static Tweener<Vector3, Transform> Position { get; } = new Tweener<Vector3, Transform>((o) => o.position, (o, v) => o.position = v);

        public static Tweener<Vector3, RectTransform> AnchoredPosition { get; } = new Tweener<Vector3, RectTransform>((o) => o.anchoredPosition, (o, v) => o.anchoredPosition = v);

        public static Tweener<float, Material> MaterialAlpha { get; } = new Tweener<float, Material>((o) => o.GetFloat("_Alpha"), (o, v) => o.SetFloat("_Alpha", v));

        public static Tweener<float, Material> MaterialDissolve { get; } = new Tweener<float, Material>((o) => o.GetFloat("_Weight"), (o, v) => o.SetFloat("_Weight", v));
    }
}
