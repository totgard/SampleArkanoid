using UnityEngine;
using UnityEngine.UI;

namespace Assets.Arkanoid.Scripts
{
    public class ScoreListener : MonoBehaviour
    {
        public Text Target;
        public string Prefix = "Score: ";

        public void UpdateValue(int time)
        {
            Target.text = Prefix + time.ToString();
        }
    }
}
