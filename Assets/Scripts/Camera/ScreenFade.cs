#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TurnBasedRPG
{
    public class ScreenFade : Singleton<ScreenFade>
    {
        private static Material material;

        private static AnimationCurve animationCurveFadeIn = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
        private static AnimationCurve animationCurveFadeOut = new AnimationCurve(new Keyframe(0, 1), new Keyframe(1, 0));

        private const float timeToFade = 1f;

        private const string useTexture = "_UseTexture";
        private const string weight = "_Weight";
        private const string alpha = "_Alpha";
        private const string texture = "_Texture";

        protected override void Awake()
        {
            base.Awake();
            material = Instance.GetComponentInChildren<Image>().material;
        }

        public static IEnumerator FadeIn()
        {
            Instance.gameObject.SetActive(true);
            float timeElapsed = 0f;

            material.SetFloat(useTexture, 1f);
            material.SetFloat(weight, 1f);

            while (timeElapsed < timeToFade)
            {
                timeElapsed += Time.deltaTime;

                material.SetFloat(weight, animationCurveFadeIn.Evaluate(timeElapsed));
                material.SetFloat(alpha, animationCurveFadeIn.Evaluate(timeElapsed));

                yield return new WaitForEndOfFrame();
            }
        }

        public static IEnumerator FadeOut()
        {
            Instance.gameObject.SetActive(true);
            float timeElapsed = 0f;

            material.SetFloat(useTexture, 1f);
            material.SetFloat(weight, 1f);

            while (timeElapsed < timeToFade)
            {
                timeElapsed += Time.deltaTime;

                material.SetFloat(weight, animationCurveFadeOut.Evaluate(timeElapsed));
                material.SetFloat(alpha, animationCurveFadeOut.Evaluate(timeElapsed));

                yield return new WaitForEndOfFrame();
            }

            Instance.gameObject.SetActive(false);
        }
    }
}
