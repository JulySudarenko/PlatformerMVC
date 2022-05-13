using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class DisplayHealthPoints
    {
        private readonly Image _healthPointsLabel;

        public DisplayHealthPoints(Image image)
        {
            _healthPointsLabel = image;
        }

        public void ShowHealthPoints(int health)
        {
            _healthPointsLabel.rectTransform.sizeDelta = new Vector2(health * 100, 100);
        }
    }
}
