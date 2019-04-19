using System.Collections.Generic;
using UnityEngine;

namespace Assets.Arkanoid.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public LevelCreator Level;
        public LevelPositionController LevelPosition;
        public GameUIManager GameUI;
        public GameResourcesProvider ResourcesProvider;
        public PlayerController Player;

        public bool StartCreateLevel;

        public List<Brick> _bricks;

        public bool IsStarted => _gameStarted;

        private bool _gameStarted;

        public void CreateGame()
        {
            LevelPosition.ResetPosition();
            GameUI.UpdateState(GameUIState.Game);
            Player.ResetPosition();
            _bricks = Level.Create();
            LevelPosition.SetFall(true);
            _gameStarted = true;
        }

        public void RestartGame()
        {
            Level.Clear();
            CreateGame();
        }

        public void GameOver(bool win = false)
        {
            _gameStarted = false;
            Player.ResetPosition();
            LevelPosition.SetFall(false);
            GameUI.UpdateState(GameUIState.GameOver);
            GameUI.GameOver.SetGameOver(win);
        }

        public void Quit()
        {
            Application.Quit();
        }

        private void RemoveBrick(Brick item)
        {
            _bricks.Remove(item);
        }

        private void Update()
        {
            if (_gameStarted && _bricks.Count == 0)
            {
                GameOver(true);
            }
        }

        private void Start()
        {
            ResourcesProvider.LoadBundle("gameassets");
            LevelPosition.SetFall(false);
            Player.OnDestroyBrick += RemoveBrick;

            if (StartCreateLevel)
            {
                CreateGame();
            }
            else
            {
                GameUI.UpdateState(GameUIState.MainMenu);
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (Level == null)
            {
                Level = FindObjectOfType<LevelCreator>();
            }

            if (Player == null)
            {
                Player = FindObjectOfType<PlayerController>();
            }

            if (LevelPosition == null)
            {
                LevelPosition = FindObjectOfType<LevelPositionController>();
            }

            if (GameUI == null)
            {
                GameUI = FindObjectOfType<GameUIManager>();
            }

            if (ResourcesProvider == null)
            {
                ResourcesProvider = FindObjectOfType<GameResourcesProvider>();
            }
        }

        private void Reset()
        {
            OnValidate();
        }
#endif
    }
}