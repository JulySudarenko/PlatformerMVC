using UnityEngine;

namespace Platformer
{
    public class CoreController
    {
        private ITimeRemaining _timeRemaining;
        private readonly Transform _core;
        private readonly TrailRenderer _trail;
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
            _config = config;
            IsActive = false;
        }

        public void Execuite(float deltaTime)
        {
            if (IsActive)
            {
                if (IsGrounded())
                {
                    SetVelocity(_velocity.Change(y: -_velocity.y));
                }
                else if (IsSided())
                {
                    SetVelocity(_velocity.Change(x: -_velocity.x));
                }
                else
                {
                    SetVelocity(_velocity + Vector3.up * (_config.GravityForce * deltaTime));
                }

                _core.position += _velocity * deltaTime;
            }
        }

        public void Throw(Vector3 position, Vector3 velocity)
        {
            _core.position = position;
            SetVelocity(velocity);
            Active(true);
            _timeRemaining = new TimeRemaining(ReturnToPool, _config.LifeCoreTime, false);
            _timeRemaining.AddTimeRemaining();
        }
        
        private void Active(bool val)
        {
            _trail.enabled = val;
            _core.gameObject.SetActive(val);
            IsActive = val;
        }

        private void SetVelocity(Vector3 velocity)
        {
            _velocity = velocity;
            _angle = Vector3.Angle(Vector3.left, _velocity);
            _axis = Vector3.Cross(Vector3.left, _velocity);
            _core.rotation = Quaternion.AngleAxis(_angle, _axis);
        }

        private bool IsGrounded()
        {
            return Physics2D.Raycast(_core.position, Vector2.down, _config.GroundLevel, _config.Mask) ||
                   Physics2D.Raycast(_core.position, Vector2.up, _config.GroundLevel, _config.Mask);
        }

        private bool IsSided()
        {
            return Physics2D.Raycast(_core.position, Vector2.left, _config.GroundLevel, _config.Mask) ||
                   Physics2D.Raycast(_core.position, Vector2.right, _config.GroundLevel, _config.Mask);
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
