using UnityEngine;

namespace Platformer
{
    public class CoreController
    {
        private readonly Transform _core;
        private readonly Transform _shootDirection;
        private CannonConfig _config;

        private readonly float _radius = 0.08f;
        private readonly float _groundLevel = 0.5f;
        private readonly float _gravityForce = -10f;
        private Vector3 _velocity;
        private bool _isStartPosition;


        public CoreController(Transform core, Transform shootDirection, CannonConfig config)
        {
            _core = core;
            _config = config;
            //_isStartPosition = true;
            //_core.SetVisible(false);
            _shootDirection = shootDirection;
        }

        public void Execuite(float deltaTime)
        {
            //_core.position -= _shootDirection.up * _config.Force * deltaTime; - работает

            if (IsGrounded())
             {
                 SetVelocity(_velocity.Change(y: -_velocity.y));
                 _core.position = _core.position.Change(y: _core.position.y + _groundLevel);
             }
             else
             {
                SetVelocity(_velocity + Vector3.up * (_gravityForce * Time.deltaTime));
                _core.position += _velocity * Time.deltaTime;
            }
        }

        public void Active(bool value)
        {
            _core.gameObject.SetActive(value);
        }

        public void Throw(Vector3 position, Vector3 velocity)
        {
            _core.position = position;
            SetVelocity(velocity);
        }

        private void SetVelocity(Vector3 velocity)
        {
            _velocity = velocity;
            var angle = Vector3.Angle(Vector3.left, _velocity);
            var axis = Vector3.Cross(Vector3.left, _velocity);
            _core.rotation = Quaternion.AngleAxis(angle, axis);
        }

        private bool IsGrounded()
        {
            return Physics2D.Raycast(_core.position, Vector2.down, _groundLevel, _config.Mask);
        }
    }
}
