using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public enum GameMode
    {
        Overworld,
        Combat
    }

    public class GameController : Singleton<GameController>
    {
        private PersistantDataSystem _dataSystem;
        private SceneManagementSystem _sceneSystem;

        private readonly Stack<IGameMode> _modes = new Stack<IGameMode>();
        private IGameMode _currentGameMode => _modes.Peek();

        private bool _isChanging;

        protected override void Awake()
        {
            base.Awake();

            _dataSystem = App.GetSystem<PersistantDataSystem>();
            _sceneSystem = App.GetSystem<SceneManagementSystem>();
        }

        private void Start()
        {
            Push(new OverworldGameMode());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Push(new CombatGameMode());
            }
        }

        public void Push(IGameMode gameMode)
        {
            if (!_isChanging)
            {
                StartCoroutine(ChangeGameMode(gameMode));
            }
        }

        public void Pop()
        {
            if (!_isChanging)
            {
                StartCoroutine(ChangeGameMode(null));
            }
        }

        private IEnumerator ChangeGameMode(IGameMode mode)
        {
            _isChanging = true;

            if (_modes.Count > 0)
            {
                yield return ScreenFade.FadeIn();

                _dataSystem.SaveAllDataInternal();

                _currentGameMode.OnExit();

                yield return _sceneSystem.UnloadAllScenes();
            }

            if (mode != null)
            {
                _modes.Push(mode);
            }
            else
            {
                _modes.Pop();
            }

            yield return _sceneSystem.LoadScene(_currentGameMode.SceneName);

            _dataSystem.LoadAllDataInternal();

            _currentGameMode.OnEnter();

            yield return ScreenFade.FadeOut();

            _isChanging = false;
        }
    }
}
