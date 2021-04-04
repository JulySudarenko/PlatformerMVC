using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class DisplayHealthPoints
    {
        private readonly Image _healthPointsLabel;
        private readonly Vector3 _startPosition;

        public DisplayHealthPoints(Image image)
        {
            _healthPointsLabel = image;
            //_startPosition = new Vector3(-225, 200, 0);
            _startPosition = image.rectTransform.position;
        }

        public void ShowHealthPoints(int health)
        {
            _healthPointsLabel.rectTransform.sizeDelta = new Vector2(health * 100, 100);
            _healthPointsLabel.rectTransform.position = _startPosition;
        }
    }
}
