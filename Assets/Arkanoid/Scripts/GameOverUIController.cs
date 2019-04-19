using UnityEngine.UI;

namespace Assets.Arkanoid.Scripts
{
    public class GameOverUIController : CanvasController
    {
        public Text PageTitle;

        public string WinText = "Win";
        public string LoseText = "Lose";

        public void SetGameOver(bool isWin)
        {
            PageTitle.text = isWin ? WinText : LoseText;
        }
    }
}
