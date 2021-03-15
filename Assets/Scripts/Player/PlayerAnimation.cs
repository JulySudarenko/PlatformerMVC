using System;
using UnityEngine;

namespace Platformer
{
    internal class PlayerAnimation
    {
        private readonly SpriteAnimator _playerAnimator;
        private readonly SpriteRenderer _spriteRenderer;
        private readonly float _animationSpeed;
        private AnimState _animationState;
       
        public PlayerAnimation(SpriteRenderer sprite, PlayerConfig config)
        {
            _playerAnimator = new SpriteAnimator(config.KnightAnimeCnf);
            _animationSpeed = config.AnimationSpeed;
            _spriteRenderer = sprite;
            _animationState = AnimState.Idle;
            _playerAnimator.StartAnimation(_spriteRenderer, _animationState, true, _animationSpeed);
        }
        
        public void OnChangeState(PlayerState state)
        {
            switch (state)
            {
                case PlayerState.Stay:
                    _animationState = AnimState.Idle;
                    break;
                case PlayerState.Walk:
                    _animationState = AnimState.Run;
                    break;
                case PlayerState.JumpUp:
                    _animationState = AnimState.JumpUp;
                    break;
                case PlayerState.JumpDown:
                    _animationState = AnimState.JumpDown;
                    break;
                case PlayerState.SwordAttack:
                    _animationState = AnimState.Attack;
                    break;
                case PlayerState.FireAttack:
                    _animationState = AnimState.FireAttack;
                    break;
                case PlayerState.Block:
                    _animationState = AnimState.Block;
                    break;
                case PlayerState.Win:
                    _animationState = AnimState.Victory;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
            
            _playerAnimator.StartAnimation(_spriteRenderer, _animationState, true, _animationSpeed);
        }

        public void FixedExecute(float deltaTime) => _playerAnimator.Execute(deltaTime);

        public void Cleanup() => _playerAnimator.Cleanup();
    }
}
