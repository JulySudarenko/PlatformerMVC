using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class MenuDisplayFactory : IMenuDisplay
    {
        private readonly MenuDisplayData _data;
        private Canvas _canvas;
        private GameObject _panel;

        public MenuDisplayFactory(MenuDisplayData data, Canvas canvas)
        {
            _data = data;
            _canvas = canvas;
        }

        public GameObject CreateMenuDisplay()
        {
            _panel = Object.Instantiate(_data.MenuPanel, _canvas.transform);
            return _panel;
        }

        public Button CreatePlayButton()
        {
            var play = Object.Instantiate(_data.ReturnButton, _panel.transform);
            return play;
        }
        
        public Button CreateRestartButton()
        {
            var restart = Object.Instantiate(_data.NewGameButton, _panel.transform);
            return restart;
        }
        
        public Button CreateQuitButton()
        {
            var quit = Object.Instantiate(_data.QuitButton, _panel.transform);
            return quit;
        }
    }
}
