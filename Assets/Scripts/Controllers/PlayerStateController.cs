using System;
using System.Collections.Generic;

namespace Platformer
{
    public class PlayerStateController : IInitialize, IFixedExecute, ICleanup, IEndGameState
    {
        public Action<int> OnChangeHealth;
        private Action<PlayerState> _onPlayerStateChange;
        private ITimeRemaining _timeRemaining;
        private readonly PlayerAnimation _playerAnimation;
        private readonly PlayerMovement _playerMovement;
        private readonly PlayerAttack _playerAttack;
        private readonly PlayerHealth _playerHealth;
        private PlayerState _state;
        private bool _isLock = false;

        public PlayerStateController(PlayerInitialization player, PlayerConfig config,
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) moveInput,
            (IUserPressButtonProxy inputSwordAttack, IUserPressButtonProxy inputFireAttack,
                IUserPressButtonProxy inputBlock) attackInput, List<int> damagingObjects)
        {
            var contactPoller = new ContactPoller(player.Collider);
            _state = PlayerState.Stay;

            _playerAnimation = new PlayerAnimation(player.SpriteRenderer, config);
            _playerMovement = new PlayerMovement(player, config, moveInput, contactPoller);
            _playerAttack = new PlayerAttack(player.Transform, config, attackInput);
            _playerHealth = new PlayerHealth(damagingObjects, contactPoller, player.Hit, player.TriggerContacts, _state, config.Health);
            
            _onPlayerStateChange += _playerAnimation.OnChangeState;
            _playerMovement.OnMoveStateChange += UpdateState;
            _playerAttack.OnAttackStateChange += UpdateState;
            _playerHealth.OnDamage += UpdateState;
        }
        
        public void Initialize()
        {
            OnChangeHealth?.Invoke(_playerHealth.HealthCount);
        }
        
        public void FixedExecute(float deltaTime)
        {
            _playerAnimation.FixedExecute(deltaTime);
            if (!_isLock)
            {
                _playerMovement.FixedExecute(deltaTime);
                _playerAttack.FixedExecute(deltaTime);
            }
        }
       
        public void IsEndGameState(PlayerState state)
        {
            UpdateState(state);
        }

        private void UpdateState(PlayerState newState)
        {
            switch (newState)
            {
                case PlayerState.Stay:
                    break;
                case PlayerState.Walk:
                case PlayerState.JumpUp:
                case PlayerState.JumpDown:
                    if (_state == PlayerState.Stay || _state == PlayerState.Walk ||
                        _state == PlayerState.JumpDown || _state == PlayerState.JumpUp)
                        _state = newState;
                    break;
                case PlayerState.SwordAttack:
                case PlayerState.FireAttack:
                case PlayerState.Block:
                    if (_state != PlayerState.Dead || _state != PlayerState.Win || _state != PlayerState.Hit)
                        _state = newState;
                    break;
                case PlayerState.Hit:
                    if (_state != PlayerState.Dead || _state != PlayerState.Win)
                    {
                        _state = newState;
                        OnChangeHealth?.Invoke(_playerHealth.HealthCount);
                        LockUp(0.5f);
                    }
                    break;
                case PlayerState.Dead:
                    _state = newState;
                    LockUp(5.0f);
                    OnChangeHealth?.Invoke(_playerHealth.HealthCount);
                    break;
                case PlayerState.Win:
                    _state = newState;
                    LockUp(5.0f);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }

            _onPlayerStateChange?.Invoke(_state);
            if (newState != PlayerState.SwordAttack && newState != PlayerState.Hit)
                _state = PlayerState.Stay;
        }

        private void LockUp(float time)
        {
            _isLock = true;
            _timeRemaining = new TimeRemaining(Unlock, time);
            _timeRemaining.AddTimeRemaining();
        }

        private void Unlock()
        {
            _isLock = false;
        }

        public void Cleanup()
        {
            _onPlayerStateChange -= _playerAnimation.OnChangeState;
            _playerMovement.OnMoveStateChange -= UpdateState;
            _playerAttack.OnAttackStateChange -= UpdateState;
            _playerHealth.OnDamage -= UpdateState;
            _playerAnimation.Cleanup();
            _playerMovement.Cleanup();
            _playerAttack.Cleanup();
            _playerHealth.Cleanup();
        }

    }
}
