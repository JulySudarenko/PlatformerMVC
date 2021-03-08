using System;
using UnityEngine;

namespace Platformer
{
    internal class PlayerStateController : IFixedExecute, ICleanup
    {
        private Action<PlayerState> _onPlayerStateChange;
        private readonly PlayerAnimation _playerAnimation;
        private readonly PlayerMovement _playerMovement;
        private readonly PlayerAttack _playerAttack;
        private PlayerState _state;
        private PlayerState _moveState;
        private PlayerState _attackState;
        private bool _isNewAttackState;

        public PlayerStateController(PlayerInitialization player, PlayerConfig config,
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) moveInput,
            (IUserPressButtonProxy inputSwordAttack, IUserPressButtonProxy inputFireAttack,
                IUserPressButtonProxy inputBlock) attackInput)
        {
            _playerAnimation = new PlayerAnimation(player.SpriteRenderer, config);
            _playerMovement = new PlayerMovement(player, config, moveInput);
            _playerAttack = new PlayerAttack(player.Transform, config, attackInput);
            _state = PlayerState.Stay;
            _onPlayerStateChange += _playerAnimation.OnChangeState;
            _playerMovement.OnMoveStateChange += ChangeMoveState;
            _playerAttack.OnAttackStateChange += ChangeAttackState;
        }

        public void FixedExecute(float deltaTime)
        {
            _playerAnimation.FixedExecute(deltaTime);
            _playerMovement.FixedExecute(deltaTime);
            _playerAttack.FixedExecute(deltaTime);
            ChangeState();
        }

        private void ChangeMoveState(PlayerState newState)
        {
            _moveState = newState;
        }

        private void ChangeAttackState(PlayerState newState)
        {
            _attackState = newState;
            _isNewAttackState = true;
        }

        private void ChangeState()
        {
            _state = _isNewAttackState ? _attackState : _moveState;
            _onPlayerStateChange?.Invoke(_state);
            _isNewAttackState = false;
        }

        public void Cleanup()
        {
            _onPlayerStateChange -= _playerAnimation.OnChangeState;
            _playerMovement.OnMoveStateChange -= ChangeMoveState;
            _playerAttack.OnAttackStateChange -= ChangeAttackState;
            _playerAnimation.Cleanup();
            _playerMovement.Cleanup();
            _playerAttack.Cleanup();
        }
    }
}
