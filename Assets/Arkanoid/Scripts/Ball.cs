using UnityEngine;
using UnityEngine.Events;

namespace Assets.Arkanoid.Scripts
{
    public class Ball : MonoBehaviour
    {
        public Rigidbody2D CurrentRigidbody;

        public UnityAction<Brick> OnContact;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var item = collision.gameObject.GetComponent<Brick>();

            if (item != null)
            {
                if (OnContact != null)
                {
                    OnContact.Invoke(item);
                }
            }
        }
    }
}
