using UnityEngine;

namespace Platformer
{
    internal class Block
    {
        private GameObject _shield;
        private Vector3 _deltaPosition;
        private readonly Transform _protected;

        public Block(GameObject shield, Transform @protected)
        {
            _shield = shield;
            _protected = @protected;
            CreateShield();
        }
        
        private void CreateShield()
        {
            _shield = Object.Instantiate(_shield);
            _deltaPosition = _protected.transform.position - _shield.transform.position;
        }
        
        public void PutUpShield()
        {
            _shield.transform.position = _protected.localScale.x > 0
                ? _protected.transform.position - _deltaPosition
                : _protected.transform.position + _deltaPosition;
            _shield.SetActive(true);
        }

        public void RemoveShield()
        {
            _shield.SetActive(false);
        }
    }
}
