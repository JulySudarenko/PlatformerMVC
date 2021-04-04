using UnityEngine.UI;

namespace Platformer
{
    public class DisplayGamePoints
    {
        private readonly Text _gamePointsLabel;

        public DisplayGamePoints(Text text)
        {
            _gamePointsLabel = text;
        }

        public void ShowGamePoints(int points)
        {
            _gamePointsLabel.text = points.ToString();
        }
    }
}
