using UnityEngine;

namespace Platformer
{
    internal class PlayerFactory : IPlayerFactory
    {
        private PlayerConfig _config;

        public PlayerFactory(PlayerConfig config)
        {
            _config = config;
        }

        public GameObject Create()
        {
            var player = Object.Instantiate(_config.PlayerPrefab);
            player.transform.position = player.transform.position.Change(x: _config.StartPointX);
            return player;
        }
    }
}
