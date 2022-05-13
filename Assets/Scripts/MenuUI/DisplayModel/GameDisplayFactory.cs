using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace Platformer
{
    public class GameDisplayFactory : IGameDisplay
    {
        private readonly GameDisplayData _data;
        private Canvas _canvas;
        private GameObject _panel;

        public GameDisplayFactory(GameDisplayData data, Canvas canvas)
        {
            _data = data;
            _canvas = canvas;
        }

        public GameObject CreateGamePanel()
        {
            _panel = Object.Instantiate(_data.GamePanel, _canvas.transform);
            return _panel;
        }

        public Image CreateHealthPointsText()
        {
            Image heart = Object.Instantiate(_data.Hearts, _panel.transform);
            return heart;
        }

        public Text CreateGamePointsText()
        {
            var text = Object.Instantiate(_data.GamePoints, _panel.transform);
            return text;
        }
    }
}
