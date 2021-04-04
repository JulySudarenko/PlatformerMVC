using UnityEngine;

namespace Platformer
{
    public sealed class MenuDisplayCommand : MainUICommand
    {
        private GameObject _menuPanel;

        public MenuDisplayCommand(GameObject panel)
        {
            _menuPanel = panel;
        }
        
        public override void Activate()
        {
            _menuPanel.SetActive(true);
        }

        public override void Cancel()
        {
            _menuPanel.SetActive(false);
        }
    }
}
