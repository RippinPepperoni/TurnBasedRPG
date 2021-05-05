using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TurnBasedRPG
{
    public class SceneManagementSystem : EntitySystem
    {
        private readonly HashSet<string> _loadedScenes = new HashSet<string>();

        private Player _player;

        private const int range = 8;
        private const int size = 20;

        public override void Initialise()
        {
            Filter = new Filter(typeof(Player));
        }

        public override void OnEntityAdded(IEntity entity)
        {
            _player = entity as Player;
        }

        public void LoadSceneByDistance(SceneContext context)
        {
            var position = _player.transform.position;
            bool isSceneInRange = Vector3.Distance(context.Bounds.ClosestPoint(position), position) < range;

            Debug.Log($"{context.SceneName}, center:{context.Bounds.center}");

            if (!_loadedScenes.Contains(context.SceneName) && isSceneInRange)
            {
                GameController.Instance.StartCoroutine(LoadScene(context.SceneName));
            }
            else if (_loadedScenes.Contains(context.SceneName) && !isSceneInRange)
            {
                if (!context.Bounds.Intersects(new Bounds(position, new Vector3(size, size))))
                {
                    GameController.Instance.StartCoroutine(UnloadScene(context.SceneName));
                }
            }
        }

        public IEnumerator LoadScene(string sceneName)
        {
            if (!_loadedScenes.Contains(sceneName))
            {
                _loadedScenes.Add(sceneName);

                yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            }
        }

        public IEnumerator UnloadScene(string sceneName)
        {
            if (_loadedScenes.Contains(sceneName))
            {
                _loadedScenes.Remove(sceneName);

                yield return SceneManager.UnloadSceneAsync(sceneName);
            }
        }

        public IEnumerator UnloadAllScenes()
        {
            foreach (var scene in _loadedScenes)
            {
                yield return SceneManager.UnloadSceneAsync(scene);
            }

            _loadedScenes.Clear();
        }


        public override void OnEntityRemoved(IEntity entity)
        {
            _player = null;
        }
    }
}
