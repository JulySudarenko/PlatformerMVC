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
        private ITimeRemaining _timeRemaining;

        public LevelCompleteManager(Transform character, List<TriggerContacts> deathZones, TriggerContacts winZone,
            IWinState state)
        {
            _startPosition = character.position;
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

        private void OnDeathZoneObjectContact(GameObject gameObject, GameObject contactView)
        {
            if (contactView.name == NameManager.PLAYER_NAME)
            {
                DeactivatePlayer();
            }
        }

        private void OnWinZoneContact(GameObject gameObject, GameObject contactView)
        {
            if (contactView.name == NameManager.PLAYER_NAME)
            {
                SceneManager.LoadScene(1);
                // _state.IsWinState();
                // DeactivatePlayer();
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
