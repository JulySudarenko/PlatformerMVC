using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    [CreateAssetMenu(fileName = "MenuDisplay", menuName = "UI/MenuDisplay", order = 0)]
    public class MenuDisplayData : ScriptableObject
    {
        public GameObject MenuPanel;
        public Button ReturnButton;
        public Button NewGameButton;
        public Button QuitButton;
    }
}
