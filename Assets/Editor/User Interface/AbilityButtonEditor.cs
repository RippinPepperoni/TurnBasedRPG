using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UI;

namespace TurnBasedRPG.Editor
{
    [CustomEditor(typeof(AbilityButton))]
    [CanEditMultipleObjects]
    public class AbilityButtonEditor : ButtonEditor
    {
        private SerializedProperty typewriterProperty;
        private SerializedProperty textProperty;

        protected override void OnEnable()
        {
            base.OnEnable();

            typewriterProperty = serializedObject.FindProperty("typewriter");
            textProperty = serializedObject.FindProperty("textComponent");
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.PropertyField(typewriterProperty);
            EditorGUILayout.PropertyField(textProperty);

            EditorGUILayout.Space();

            base.OnInspectorGUI();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
