using UnityEngine;
using UnityEngine.UI;

namespace Assets.Arkanoid.Scripts
{
    public class TimerListener : MonoBehaviour
    {
        public Text Target;
        public string Prefix = "Next fall: ";

        private const string Format = "N";

        public void UpdateTime(float time)
        {
            Target.text = Prefix + time.ToString(Format);
        }
    }
}
