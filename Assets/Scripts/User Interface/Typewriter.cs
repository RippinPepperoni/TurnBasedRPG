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

        private string text;

        public string Text
        {
            set => StartCoroutine(SetText(value));
        }

        public IEnumerator SetText(string value, float endDelay = 0f)
        {
            text = value;
            int printedCharacterCount = 0;

            do
            {
                textComponent.text = text.Substring(0, printedCharacterCount) + openingColourDelimeter + text.Substring(printedCharacterCount) + closingColourDelimeter;

                if (text.Substring(printedCharacterCount).ToCharArray().Length > 0)
                {
                    char currentCharacter = text.Substring(printedCharacterCount).ToCharArray()[0];

                    yield return new WaitForSeconds(GetDelay(currentCharacter));
                }

                printedCharacterCount++;
            }
            while (printedCharacterCount <= text.Length);

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

