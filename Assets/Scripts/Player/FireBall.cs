using UnityEngine;

namespace Platformer
{
    internal class FireBall
    {
        public bool IsActive;
        private readonly Transform _fireBall;
        private readonly TrailRenderer _trail;
        private readonly Rigidbody2D _rigidbody;
        private ITimeRemaining _timeRemaining;
        private readonly float _lifeTime;

        public FireBall(Transform fireBall, float lifeTime, DamagingObjects damagingObjects)
        {
            _fireBall = fireBall;
            _lifeTime = lifeTime;
            _rigidbody = fireBall.gameObject.GetOrAddComponent<Rigidbody2D>();
            if (_fireBall.TryGetComponent<TrailRenderer>(out var component))
            {
                _trail = component;
            }

            damagingObjects.AddDamagingObject(fireBall.gameObject.GetInstanceID());
            IsActive = false;
        }

        public void Shoot(Vector3 position, Vector3 velocity)
        {
            _fireBall.position = position;
            Active(true);
            _rigidbody.AddForce(velocity, ForceMode2D.Impulse);
            _timeRemaining = new TimeRemaining(ReturnToPool, _lifeTime, false);
            _timeRemaining.AddTimeRemaining();
        }

        private void Active(bool val)
        {
            _trail.enabled = val;
            _fireBall.gameObject.SetActive(val);
            IsActive = val;
        }

        private void ReturnToPool()
        {
            Active(false);
            _fireBall.localPosition = Vector3.zero;
            _fireBall.localRotation = Quaternion.identity;
            _trail.Clear();
            _timeRemaining.RemoveTimeRemaining();
        }

        public void Cleanup()
        {
            _timeRemaining.RemoveTimeRemaining();
        }
    }
}
