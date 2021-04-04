using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Platformer
{
    public class DisplayCommand
    {
        private readonly MenuDisplayCommand _menuDisplayCommand;
        private readonly GameDisplayCommand _gameDisplayCommand;
        private readonly Button _playButton;
        private readonly Button _restartButton;
        private readonly Button _quitButton;
        private MainUICommand _currentWindow;

        public DisplayCommand(MenuDisplayCommand menuDisplayCommand, GameDisplayCommand gameDisplayCommand,
            Button playButton, Button quitButton, Button restartButton)
        {
            _menuDisplayCommand = menuDisplayCommand;
            _gameDisplayCommand = gameDisplayCommand;
            _restartButton = restartButton;
            _playButton = playButton;
            _quitButton = quitButton;
        }

        public void MakeStartPosition()
        {
            _menuDisplayCommand.Cancel();
            _gameDisplayCommand.Activate();
            _currentWindow = _gameDisplayCommand;
        }

        public void AddButtonsListener()
        {
            _restartButton.onClick.AddListener(RestartGame);
            _playButton.onClick.AddListener(ChangePanelOnClick);
            _quitButton.onClick.AddListener(Exit);
        }

        public void CheckInput()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                ChangePanel(StateUI.PanelOne);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                ChangePanel(StateUI.PanelTwo);
            }
        }

        private void ChangePanel(StateUI stateUI)
        {
            if (_currentWindow != null)
            {
                _currentWindow.Cancel();
            }

            switch (stateUI)
            {
                case StateUI.PanelOne:
                    _currentWindow = _menuDisplayCommand;
                    Time.timeScale = 0.0f;
                    break;
                case StateUI.PanelTwo:
                    _currentWindow = _gameDisplayCommand;
                    Time.timeScale = 1.0f;
                    break;
                default:
                    break;
            }

            _currentWindow.Activate();
        }

        private void ChangePanelOnClick()
        {
            ChangePanel(StateUI.PanelTwo);
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
        
        public void Exit()
        {
            Application.Quit();
        }
    }
}
