using UnityEngine;

namespace Platformer
{
    public class CoreController
    {
        private ITimeRemaining _timeRemaining;
        private readonly Transform _core;
        private readonly TrailRenderer _trail;
        private readonly Rigidbody2D _rigidbody;
        private readonly CannonConfig _config;
        private Vector3 _axis;
        private Vector3 _velocity;
        private float _angle;
        public bool IsActive { get; private set; }

        public CoreController(Transform core, CannonConfig config)
        {
            _core = core;
            if (_core.TryGetComponent<TrailRenderer>(out var component))
            {
                _trail = component;
            }

            _rigidbody = _core.gameObject.GetOrAddComponent<Rigidbody2D>();
            _config = config;
            IsActive = false;
        }

        public void Throw(Vector3 position, Vector3 velocity)
        {
            _core.position = position;
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.angularVelocity = 0;
            Active(true);
            _rigidbody.AddForce(velocity, ForceMode2D.Impulse);
            _timeRemaining = new TimeRemaining(ReturnToPool, _config.LifeCoreTime, false);
            _timeRemaining.AddTimeRemaining();
        }

        private void Active(bool val)
        {
            _trail.enabled = val;
            _core.gameObject.SetActive(val);
            IsActive = val;
        }

        private void ReturnToPool()
        {
            Active(false);
            _core.localPosition = Vector3.zero;
            _core.localRotation = Quaternion.identity;
            _trail.Clear();
        }
    }
}
