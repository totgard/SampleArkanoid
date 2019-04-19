using UnityEngine;

namespace Assets.Arkanoid.Scripts
{
    public class GameUIManager : MonoBehaviour
    {
        public MenuUIController Menu;
        public GameOverUIController GameOver;
        public GameUIController Game;

        private GameUIState _lastState;

        public void UpdateState(GameUIState state)
        {
            Menu.Set(state == GameUIState.MainMenu);
            GameOver.Set(state == GameUIState.GameOver);
            Game.Set(state == GameUIState.Game);

            _lastState = state;
        }

#if UNITY_EDITOR

        private void OnValidate()
        {
            if (Menu == null)
            {
                Menu = FindObjectOfType<MenuUIController>();
            }

            if (GameOver == null)
            {
                GameOver = FindObjectOfType<GameOverUIController>();
            }

            if (Game == null)
            {
                Game = FindObjectOfType<GameUIController>();
            }
        }

        private void Reset()
        {
            OnValidate();
        }

#endif
    }
}
