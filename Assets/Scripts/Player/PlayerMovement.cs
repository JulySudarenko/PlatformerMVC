using System;
using UnityEngine;

namespace Platformer
{
    internal class PlayerMovement
    {
        public Action<PlayerState> OnMoveStateChange;
        private readonly Transform _player;
        private readonly PlayerConfig _config;
        private readonly IUserInputProxy _horizontalInputProxy;
        private readonly IUserInputProxy _verticalInputProxy;
        private readonly Vector3 _leftScale = new Vector3(-1, 1, 1);
        private readonly Vector3 _rightScale = new Vector3(1, 1, 1);
        private PlayerState _playerState;
        private float _jumpForce = 0f;
        private float _horizontal;
        private float _vertical;
        private bool _goSideWay;
        private bool _doJump;
        
        public PlayerMovement(Transform player, PlayerConfig config,
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input)
        {
            _player = player;
            _config = config;
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
            if (_goSideWay) GoSideWay(deltaTime);
            DoJump(deltaTime);
            OnMoveStateChange?.Invoke(_playerState);
        }

        private void DoJump(float deltaTime)
        {
            if (IsGrounded())
            {
                _playerState = _goSideWay ? PlayerState.Walk : PlayerState.Stay;
                _jumpForce = (_doJump && _jumpForce == 0f) ? _config.JumpStartForce : 0f;
                _player.position += Vector3.up * (_jumpForce * deltaTime);
            }
            else
            {
                _jumpForce += _config.GravityForce * deltaTime;
                _player.position += Vector3.up * (deltaTime * _jumpForce);
                _playerState = _jumpForce > 0 ? PlayerState.JumpUp : PlayerState.JumpDown;
            }
        }

        private void GoSideWay(float deltaTime)
        {
            _player.localScale = _horizontal < 0 ? _leftScale : _rightScale;
            _player.position += Vector3.right * (deltaTime * _config.WalkSpeed * (_horizontal < 0 ? -1 : 1));
        }

        private bool IsGrounded()
        {
            RaycastHit2D hit = Physics2D.Raycast(_player.position, Vector2.down, _config.GroundDistance, _config.Mask);
            return hit;
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }
    }
}
