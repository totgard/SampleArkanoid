using UnityEngine;
using UnityEngine.Events;

namespace Assets.Arkanoid.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        public Player CurrentPlayer;
        public Ball Ball;

        public int Score
        {
            get => _score;

            set
            {
                _score = value;
                if (OnChangeScore != null)
                {
                    OnChangeScore.Invoke(_score);
                }
            }
        }

        public float Speed = 1;

        public Vector3 FireDirection = Vector3.up;

        public UnityAction<Brick> OnDestroyBrick;

        public IntEvent OnChangeScore;

        private Bounds _cameraBounds;
        private int _score;

        public void Move(MoveDirection direction)
        {
            Move((int)direction);
        }

        public void Fire()
        {
            if (Ball.CurrentRigidbody.velocity == Vector2.zero)
            {
                Ball.transform.SetParent(null);
                Ball.CurrentRigidbody.AddForce(FireDirection);
            }
        }

        public void ResetPosition()
        {
            CurrentPlayer.transform.localPosition = Vector3.zero;
            Ball.CurrentRigidbody.velocity = Vector2.zero;
            Ball.transform.SetParent(CurrentPlayer.BallSpawn);
            Ball.transform.localPosition = Vector3.zero;
        }

        private void Move(int direction)
        {
            var targetPositon = CurrentPlayer.transform.position + Vector3.right * direction * Speed;
            if (targetPositon.x < _cameraBounds.max.x
                && targetPositon.x > _cameraBounds.min.x)
            {
                CurrentPlayer.transform.position += Vector3.right * direction * Speed;
            }
        }

        private void HitBrickAction(Brick brick)
        {
            brick.Health--;
            if (brick.Health <= 0)
            {
                Score++;
                if (OnDestroyBrick != null)
                {
                    OnDestroyBrick.Invoke(brick);
                }
                Destroy(brick.gameObject);
            }
        }

        private bool IsValidPosition(Vector3 position)
        {
            var result = true;
            result &= _cameraBounds.min.x <= CurrentPlayer.transform.position.x;
            result &= _cameraBounds.max.x >= CurrentPlayer.transform.position.x;

            return result;
        }

        private void Awake()
        {
            _cameraBounds = Camera.main.OrthographicBounds();
            Ball.OnContact += HitBrickAction;
        }

        private void Start()
        {
            Score = 0;
        }

#if UNITY_EDITOR

        private void OnValidate()
        {
            if (Ball == null)
            {
                Ball = FindObjectOfType<Ball>();
            }
        }

        private void Reset()
        {
            OnValidate();
        }

#endif
    }
}
