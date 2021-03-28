using UnityEngine;

namespace Platformer
{
    internal class InitializeCharacter
    {
        public readonly Transform Transform;
        public readonly SpriteRenderer SpriteRenderer;
        public readonly Rigidbody2D Rigidbody;
        public readonly Collider2D Collider;
        private readonly GameObject _enemy;

        public InitializeCharacter(IFactory factory)
        {
            _enemy = factory.Create();
            Transform = _enemy.transform;
            SpriteRenderer = _enemy.GetComponentInChildren<SpriteRenderer>();
            Collider = _enemy.GetOrAddComponent<Collider2D>();
            Rigidbody = _enemy.GetOrAddComponent<Rigidbody2D>();
        }
    }
}
