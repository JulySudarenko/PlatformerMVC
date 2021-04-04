namespace Platformer
{
    public class DisplayInitialization : IInitialize, IExecute, ICleanup
    {
        private readonly PlayerStateController _playerController;
        private readonly MenuDisplayFactory _menuDisplayFactory;
        private readonly GameDisplayFactory _gameDisplayFactory;
        private DisplayCommand _displayCommand;
        private DisplayHealthPoints _healthPoints;
        private DisplayGamePoints _gamePoints;

        public DisplayInitialization(UIData data, PlayerStateController playerController)
        {
            _menuDisplayFactory = new MenuDisplayFactory(data.MenuDisplayData, data.Canvas);
            _gameDisplayFactory = new GameDisplayFactory(data.GameDisplayData, data.Canvas);
            _playerController = playerController;
            _playerController.OnChangeHealth += ShowPlayerHealth;
        }

        public void Initialize()
        {
            var menuDisplayInitialization = new MenuDisplayInitialization(_menuDisplayFactory);
            var gameDisplayInitialization = new GameDisplayInitialization(_gameDisplayFactory);

            var gameDisplayCommand = new GameDisplayCommand(gameDisplayInitialization.GetGamePanel());
            var menuDisplayCommand = new MenuDisplayCommand(menuDisplayInitialization.GetMenuPanel());

            _displayCommand = new DisplayCommand(menuDisplayCommand, gameDisplayCommand,
                menuDisplayInitialization.GetPlayButton(), menuDisplayInitialization.GetQuitButton(), menuDisplayInitialization.GetRestartButton());
            _displayCommand.MakeStartPosition();
            _displayCommand.AddButtonsListener();

            _healthPoints = new DisplayHealthPoints(gameDisplayInitialization.GetHealthPointsText());
            _gamePoints = new DisplayGamePoints(gameDisplayInitialization.GetGamePointsText());
        }

        private void ShowGameScore(int points)
        {
            _gamePoints.ShowGamePoints(points);
        }

        private void ShowPlayerHealth(int points)
        {
            _healthPoints.ShowHealthPoints(points);
        }

        public void Execute(float deltaTime)
        {
            _displayCommand.CheckInput();
        }

        public void Cleanup()
        {
            _playerController.OnChangeHealth -= ShowPlayerHealth;
        }
    }
}
