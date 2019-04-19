using UnityEngine;
using UnityEngine.Events;

namespace Assets.Arkanoid.Scripts
{
    public class DeadZone : MonoBehaviour
    {
        public UnityEvent OnEnter;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (OnEnter != null)
            {
                OnEnter.Invoke();
            }
        }
    }
}
