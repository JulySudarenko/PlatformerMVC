using System;
using UnityEngine;

namespace Platformer
{
    internal class CoinsListener : ICleanup
    {
        public event Action<bool, Vector3, int> CoinIsTaken;
        private GameObject _coin;
        private TriggerContacts _coinTrigger;
        private int _contactID;

        public CoinsListener(GameObject coin, int contactID)
        {
            _coin = coin;
            _contactID = contactID;
            _coinTrigger = coin.gameObject.GetOrAddComponent<TriggerContacts>();
            _coinTrigger.IsContact += OnContact;
        }

        private void OnContact(int triggerObjectID)
        {
            if (triggerObjectID == _contactID)
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
