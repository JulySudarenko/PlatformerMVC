using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class GameDisplayInitialization
    {
        private IGameDisplay _gameDisplay;

        public GameDisplayInitialization(IGameDisplay gameDisplay)
        {
            _gameDisplay = gameDisplay;
        }

        public GameObject GetGamePanel()
        {
            return _gameDisplay.CreateGamePanel();
        }
        
        public Image GetHealthPointsText()
        {
            return _gameDisplay.CreateHealthPointsText();
        }

        public Text GetGamePointsText()
        {
            return _gameDisplay.CreateGamePointsText();
        }
    }
}
