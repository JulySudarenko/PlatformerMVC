using UnityEngine;

namespace Platformer
{
    internal class CoinsInitialization
    {
        private GameObject _coin;
        public Transform _coinTransform;
        public SpriteRenderer _coinSpriteRenderer;
        public TriggerContacts _coinContacts;
            
        public CoinsInitialization(ICoinsFactory factory)
        {
            _coin = factory.CreateCoin();
            _coinTransform = _coin.transform;
            _coinSpriteRenderer = _coin.GetComponentInChildren<SpriteRenderer>();
            _coinContacts = _coin.GetOrAddComponent<TriggerContacts>();
        }
    }
}
