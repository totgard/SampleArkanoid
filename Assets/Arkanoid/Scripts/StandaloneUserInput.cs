using UnityEngine;

namespace Assets.Arkanoid.Scripts
{
    public class StandaloneUserInput : MonoBehaviour
    {
        public KeyCode FireKey = KeyCode.Space;
        public string MoveAxis = "Horizontal";

        public GameManager Game;

        private float _horizontalInput;

        private void Update()
        {
            if (!Game.IsStarted)
            {
                return;
            }

            if (Input.GetKeyDown(FireKey))
            {
                Game.Player.Fire();
            }

            _horizontalInput = Input.GetAxis(MoveAxis);

            if (_horizontalInput != 0)
            {
                Game.Player.Move(_horizontalInput > 0 ? MoveDirection.Right : MoveDirection.Left);
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (Game == null)
            {
                Game = FindObjectOfType<GameManager>();
            }
        }

        private void Reset()
        {
            OnValidate();
        }
#endif
    }
}
