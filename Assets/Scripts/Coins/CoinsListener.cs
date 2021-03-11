using System;
using UnityEngine;

namespace Platformer
{
    internal class CoinsListener : ICleanup
    {
        public event Action<bool, Vector3, int> CoinIsTaken;
        private GameObject _coin;
        private TriggerContacts _coinTrigger;

        public CoinsListener(GameObject coin)
        {
            _coin = coin;
            _coinTrigger = coin.gameObject.GetOrAddComponent<TriggerContacts>();
            _coinTrigger.IsContact += OnContact;
        }

        private void OnContact(GameObject gameObject, GameObject triggerObject)
        {
            if (triggerObject.name == NameManager.PLAYER_NAME)
            {
                CoinIsTaken?.Invoke(false, Vector3.zero, 0);
            }
        }

        public void Cleanup()
        {
            _coinTrigger.IsContact -= OnContact;
        }
    }
}
