#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TurnBasedRPG
{
    public class Typewriter : MonoBehaviour
    {
        [SerializeField] private Text textComponent;

        private readonly HashSet<char> punctutationCharacters = new HashSet<char> { '.', ',', '!', '?' };

        private const float delay = 0.02f;
        private const float delayModifier = 6f;

        private const string openingColourDelimeter = "<color=#FFFFFF00>";
        private const string closingColourDelimeter = "</color>";

        public string Text
        {
            set => StartCoroutine(SetText(value));
        }

        public IEnumerator SetText(string text, float endDelay = 0f)
        {
            int count = 0;

            while (count <= text.Length)
            {
                textComponent.text = text.Substring(0, count) + openingColourDelimeter + text.Substring(count) + closingColourDelimeter;

                if (text.Substring(count).ToCharArray().Length > 0)
                {
                    char currentCharacter = text.Substring(count).ToCharArray()[0];

                    yield return new WaitForSeconds(GetDelay(currentCharacter));
                }

                count++;
            }

            if (endDelay > 0)
            {
                yield return new WaitForSeconds(endDelay);
            }
        }

        private float GetDelay(char character)
        {
            float finalDelay = delay;

            if (punctutationCharacters.Contains(character))
            {
                finalDelay *= delayModifier;
            }

            return finalDelay;
        }

        public void Stop()
        {
            StopAllCoroutines();
        }

        private void OnDestroy()
        {
            Stop();
        }
    }
}

