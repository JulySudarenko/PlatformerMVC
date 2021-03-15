using System;
using UnityEngine;

namespace Platformer
{
    internal class PlayerMovement
    {
        public Action<PlayerState> OnMoveStateChange;
        private readonly Transform _player;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly PlayerConfig _config;
        private readonly IUserInputProxy _horizontalInputProxy;
        private readonly IUserInputProxy _verticalInputProxy;
        private readonly ContactPoller _contactPoller;
        private readonly Vector3 _leftScale = new Vector3(-1, 1, 1);
        private readonly Vector3 _rightScale = new Vector3(1, 1, 1);
        private PlayerState _playerState;
        private float _newVelocity;
        private float _horizontal;
        private float _vertical;
        private bool _goSideWay;
        private bool _doJump;

        public PlayerMovement(PlayerInitialization player, PlayerConfig config,
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input)
        {
            _player = player.Transform;
            _rigidbody2D = player.Rigidbody;
            _config = config;
            _contactPoller = new ContactPoller(player.Collider);
            _horizontalInputProxy = input.inputHorizontal;
            _verticalInputProxy = input.inputVertical;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
        }

        private void VerticalOnAxisOnChange(float value) => _vertical = value;
        private void HorizontalOnAxisOnChange(float value) => _horizontal = value;

        public void FixedExecute(float deltaTime)
        {
            _goSideWay = Mathf.Abs(_horizontal) > _config.MovingThresh;
            _doJump = _vertical > 0;
            _contactPoller.Execute(deltaTime);

            _newVelocity = 0.0f;

            GoSideWay(deltaTime);
            DoJump();
            DoAnimation();
        }

        private void DoJump()
        {
            if (_contactPoller.IsGrounded && 
                _doJump && 
                _rigidbody2D.velocity.y <= _config.JumpThresh)
            {
                _rigidbody2D.AddForce(Vector2.up * _config.JumpStartForce, ForceMode2D.Impulse);
            }
        }

        private void GoSideWay(float deltaTime)
        {
            if (_goSideWay &&
                (_horizontal > 0 || !_contactPoller.HasLeftContact) &&
                (_horizontal < 0 || !_contactPoller.HasRightContact))
            {
                _newVelocity = deltaTime * _config.WalkSpeed * (_horizontal < 0 ? -1 : 1);
                _player.localScale = _horizontal < 0 ? _leftScale : _rightScale;
            }

            _rigidbody2D.velocity = _rigidbody2D.velocity.Change(x: _newVelocity);
        }

        private void DoAnimation()
        {
            if (_contactPoller.IsGrounded)
            {
                _playerState = _goSideWay ? PlayerState.Walk : PlayerState.Stay;
            }
            else
            {
                _playerState = _doJump ? PlayerState.JumpUp : PlayerState.JumpDown;
            }

            OnMoveStateChange?.Invoke(_playerState);
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }
    }
}
