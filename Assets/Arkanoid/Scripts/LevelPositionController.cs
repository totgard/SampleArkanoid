using UnityEngine;

namespace Assets.Arkanoid.Scripts
{
    public class LevelPositionController : MonoBehaviour
    {
        public Transform Target;

        public float Period = 1;

        public float FallSpeed = 1.0f;

        public FloatEvent OnChangeTime;

        private float _lastTime;

        private Vector3 _startPostion;

        private bool _isFalling;

        public void SetFall(bool state)
        {
            _isFalling = state;
        }

        public void ResetPosition()
        {
            Target.position = _startPostion;
        }

        private void Fall()
        {
            Target.position += Vector3.down * FallSpeed;
        }

        private void Update()
        {
            if (!_isFalling)
            {
                return;
            }

            _lastTime += Time.deltaTime;

            if (_lastTime > Period)
            {
                _lastTime = 0.0f;
                Fall();
            }

            if (OnChangeTime != null)
            {
                OnChangeTime.Invoke(_lastTime);
            }
        }

        private void Awake()
        {
            _startPostion = Target.position;
        }
    }
}
