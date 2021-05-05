using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

namespace TurnBasedRPG.Editor
{
    [CustomEditor(typeof(SceneRuntimeSet))]
    public class SceneRuntimeSetEditor : UnityEditor.Editor
    {
        private SerializedProperty itemsProperty;

        private readonly HashSet<string> _closedScenes = new HashSet<string>();

        private void OnEnable()
        {
            itemsProperty = serializedObject.FindProperty("items");
        }

        public override void OnInspectorGUI()
        {
            if(GUILayout.Button("Save"))
            {
                itemsProperty.ClearArray();

                OpenAllScenesInProject();
                Save();
                ClosePreviouslyUnloadedScenes();
            }

            serializedObject.ApplyModifiedProperties();
        }

        private void OpenAllScenesInProject()
        {
            EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;

            _closedScenes.Clear();

            for (int i = 0; i < scenes.Length; i++)
            {
                var scene = scenes[i];

                if (!SceneManager.GetSceneByPath(scene.path).isLoaded)
                {
                    _closedScenes.Add(scene.path);

                    EditorSceneManager.OpenScene(scene.path, OpenSceneMode.Additive);
                }
            }
        }

        private void Save()
        {
            GameObject[] anchorObjects = GameObject.FindGameObjectsWithTag("Anchor");

            itemsProperty.arraySize = anchorObjects.Length;

            for (int i = 0; i < anchorObjects.Length; i++)
            {
                if (anchorObjects[i].TryGetComponent(out Tilemap tilemap))
                {
                    tilemap.CompressBounds();

                    SerializedProperty arrayProperty = itemsProperty.GetArrayElementAtIndex(i);

                    arrayProperty.FindPropertyRelative("SceneName").stringValue = anchorObjects[i].scene.name;
                    arrayProperty.FindPropertyRelative("Bounds").boundsValue = new Bounds(tilemap.cellBounds.center, tilemap.cellBounds.size);

                    Debug.Log($"Added {anchorObjects[i].scene.name} to set!");
                }
            }
        }

        private void ClosePreviouslyUnloadedScenes()
        {
            foreach (var scene in _closedScenes)
            {
                EditorSceneManager.CloseScene(SceneManager.GetSceneByPath(scene), true);
            }
        }
    }
}
