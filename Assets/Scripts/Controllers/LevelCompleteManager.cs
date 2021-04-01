using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer
{
    internal class LevelCompleteManager : ICleanup
    {
        private readonly IWinState _state;
        private readonly List<TriggerContacts> _deathZones;
        private readonly TriggerContacts _winZone;
        private readonly TriggerContacts _character;
        private readonly Vector3 _startPosition;
        private readonly float _timeToReload = 3.0f;
        private readonly int _contactID;
        private ITimeRemaining _timeRemaining;

        public LevelCompleteManager(Transform character, List<TriggerContacts> deathZones, TriggerContacts winZone,
            IWinState state, int contactID)
        {
            _startPosition = character.position;
            _contactID = contactID;
            _character = character.gameObject.GetOrAddComponent<TriggerContacts>();
            _state = state;
            _deathZones = deathZones;
            _winZone = winZone;

            foreach (var zone in _deathZones)
            {
                zone.IsContact += OnDeathZoneObjectContact;
            }

            _winZone.IsContact += OnWinZoneContact;
        }

        private void OnDeathZoneObjectContact(int contactID)
        {
            if (contactID == _contactID)
            {
                DeactivatePlayer();
            }
        }

        private void OnWinZoneContact(int contactID)
        {
            if (contactID == _contactID)
            {
                SceneManager.LoadScene(1);
            }
        }

        private void DeactivatePlayer()
        {
            _character.gameObject.SetActive(false);
            _character.transform.position = Vector3.zero;
            _character.transform.rotation = Quaternion.identity;
            _timeRemaining = new TimeRemaining(ActivatePlayer, _timeToReload, false);
            _timeRemaining.AddTimeRemaining();
        }

        private void ActivatePlayer()
        {
            _character.transform.position = _startPosition;
            _character.gameObject.SetActive(true);
        }

        public void Cleanup()
        {
            foreach (var zone in _deathZones)
            {
                zone.IsContact -= OnDeathZoneObjectContact;
            }

            _winZone.IsContact -= OnWinZoneContact;
        }
    }
}
