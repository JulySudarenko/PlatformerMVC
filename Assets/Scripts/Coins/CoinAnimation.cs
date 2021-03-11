using UnityEngine;

namespace Platformer
{
    internal class CoinAnimation
    {
        private readonly SpriteRenderer _spriteRenderer;
        private readonly SpriteAnimator _coinsAnimator;

        public CoinAnimation(Transform coin, ItemConfig config)
        {
            _coinsAnimator = new SpriteAnimator(config.ItemAnimatorCnf);
            _spriteRenderer = coin.GetComponentInChildren<SpriteRenderer>();
            _coinsAnimator.StartAnimation(_spriteRenderer, AnimState.Idle, true, config.ItemAnimationSpeed);
        }

        public void Execute(float deltaTime) => _coinsAnimator.Execute(deltaTime);
    }
}
