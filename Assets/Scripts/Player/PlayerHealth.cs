using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    internal class PlayerHealth
    {
        public Action<PlayerState> OnDamage;
        private readonly List<int> _damagingObjects;
        private readonly ContactPoller _contactPoller;
        private readonly TriggerContacts _triggerContacts;
        private readonly Hit _playerContacts;
        private readonly Transform _player;
        private PlayerState _state;
        private int _healthCount;


        public PlayerHealth(List<int> damagingObjects, ContactPoller contactPoller, Transform player,
            Hit playerContacts, TriggerContacts triggerContacts, int healthCount)
        {
            _damagingObjects = damagingObjects;
            _contactPoller = contactPoller;
            _playerContacts = playerContacts;
            _triggerContacts = triggerContacts;
            _player = player;
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
                    ChangePlayerState();
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

        public void StatusTrack(PlayerState state)
        {
            _state = state;
        }

        public void Cleanup()
        {
            _playerContacts.IsContact -= OnPlayerContact;
        }
    }
}
