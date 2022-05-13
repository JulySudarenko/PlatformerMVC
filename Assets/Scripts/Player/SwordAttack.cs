using UnityEngine;

namespace Platformer
{
    internal class SwordAttack
    {
        private GameObject _sword;
        private DamagingObjects _damagingObjects;
        private Vector3 _deltaPosition;
        private readonly Transform _attaсker;

        public SwordAttack(GameObject sword, DamagingObjects damagingObjects, Transform attaсker)
        {
            _sword = sword;
            _damagingObjects = damagingObjects;
            _attaсker = attaсker;
            CreateSword();
        }

        private void CreateSword()
        {
            _sword = Object.Instantiate(_sword);
            _damagingObjects.AddDamagingObject(_sword.GetInstanceID());
            _deltaPosition = _attaсker.transform.position - _sword.transform.position;
        }

        public void StrikeSword()
        {
            _sword.transform.position = _attaсker.localScale.x > 0
                ? _attaсker.transform.position - _deltaPosition
                : _attaсker.transform.position + _deltaPosition;
            _sword.SetActive(true);
        }

        public void RemoveSword()
        {
            _sword.SetActive(false);
        }
    }
}
