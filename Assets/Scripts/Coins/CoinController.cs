using UnityEngine;

namespace Platformer
{
    internal class CoinController
    {
        public bool IsActive;
        
        private CoinAnimation _coinAnimation;
        private CoinsListener _coinListener;
        private Transform _coin;

        public CoinController(Transform coin, ItemConfig config, int contactID)
        {
            _coin = coin;
            _coinAnimation = new CoinAnimation(coin, config);
            _coinListener = new CoinsListener(_coin.gameObject, contactID);
            _coinListener.CoinIsTaken += Activate;
            IsActive = false;
        }

        public void Activate(bool flag, Vector3 position, int delta)
        {
            _coin.position = position;
            _coin.position = _coin.position.Change(y: _coin.position.y + delta);
            _coin.gameObject.SetActive(flag);
            IsActive = flag;

        }

        public void Execute(float deltaTime)
        {
            _coinAnimation.Execute(deltaTime);
        }

        public void Cleanup()
        {
            _coinListener.Cleanup();
            _coinListener.CoinIsTaken -= Activate;
        }
    }
}
