using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UI;

namespace TurnBasedRPG.Editor
{
    [CustomEditor(typeof(ActionButton))]
    [CanEditMultipleObjects]
    public class ActionButtonEditor : ButtonEditor
    {
        private SerializedProperty typewriterProperty;
        private SerializedProperty textProperty;

        protected override void OnEnable()
        {
            base.OnEnable();

            typewriterProperty = serializedObject.FindProperty("typewriter");
            textProperty = serializedObject.FindProperty("description");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.PropertyField(typewriterProperty);
            EditorGUILayout.PropertyField(textProperty);

            EditorGUILayout.Space();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
