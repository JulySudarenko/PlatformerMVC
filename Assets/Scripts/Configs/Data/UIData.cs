using UnityEngine;
using static Platformer.Extentions;

namespace Platformer
{
    [CreateAssetMenu(fileName = "UIData", menuName = "UI/UIData")]
    public class UIData : ScriptableObject
    {
        [SerializeField] private string _gameDisplayData; 
        [SerializeField] private string _menuDisplayData; 
        private GameDisplayData _panelGame;
        private MenuDisplayData _panelMenu;
        private Canvas _canvas;

        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }
        
        public GameDisplayData GameDisplayData
        {
            get
            {
                if (_panelGame == null)
                {
                    _panelGame = Load<GameDisplayData>("UI/" + _gameDisplayData);
                }

                return _panelGame;
            }
        }
        
        public MenuDisplayData MenuDisplayData
        {
            get
            {
                if (_panelMenu == null)
                {
                    _panelMenu = Load<MenuDisplayData>("UI/" + _menuDisplayData);
                }

                return _panelMenu;
            }
        }
    }
}
