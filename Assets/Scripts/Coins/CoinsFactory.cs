using UnityEngine;

namespace Platformer
{
    internal class CoinsFactory : ICoinsFactory
    {
        private ItemConfig _config;

        public CoinsFactory(ItemConfig config)
        {
            _config = config;
        }

        public GameObject CreateCoin()
        {
            var coin = Object.Instantiate(_config.ItemPrefab);
            return coin;
        }
    }
}
