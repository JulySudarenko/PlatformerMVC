using System;
using System.Collections.Generic;

namespace Platformer
{
    internal class PlayerHealth
    {
        public Action<PlayerState> OnDamage;
        private readonly List<int> _damagingObjects;
        private readonly ContactPoller _contactPoller;
        private readonly TriggerContacts _triggerContacts;
        private readonly Hit _playerContacts;
        private readonly PlayerState _state;
        private int _healthCount;


        public PlayerHealth(List<int> damagingObjects, ContactPoller contactPoller, 
            Hit playerContacts, TriggerContacts triggerContacts,
            PlayerState state, int healthCount)
        {
            _damagingObjects = damagingObjects;
            _contactPoller = contactPoller;
            _playerContacts = playerContacts;
            _triggerContacts = triggerContacts;
            _state = state;
            _healthCount = healthCount;
            _triggerContacts.IsContact += OnPlayerContact;
            _playerContacts.IsContact += OnPlayerContact;
        }

        public int HealthCount => _healthCount;

        private void OnPlayerContact(int contactID)
        {
            for (int i = 0; i < _damagingObjects.Count; i++)
            {
                if (_damagingObjects[i] == contactID)
                {
                    if (_state == PlayerState.Block)
                    {
                        if (_contactPoller.HasLeftContact || _contactPoller.HasTopContact)
                        {
                            ChangePlayerState();
                        }
                    }
                    else
                    {
                        ChangePlayerState();
                    }
                }
            }
        }

        private void ChangePlayerState()
        {
            _healthCount--;
            
            if (_healthCount > 0)
                OnDamage?.Invoke(PlayerState.Hit);
            else 
                OnDamage?.Invoke(PlayerState.Dead); 
        }
        
        
        public void Cleanup()
        {
            _playerContacts.IsContact -= OnPlayerContact;
        }
    }
}
