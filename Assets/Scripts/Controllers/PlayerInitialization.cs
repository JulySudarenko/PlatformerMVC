using UnityEngine;

namespace Platformer
{
    internal class PlayerInitialization
    {
        public readonly Transform Transform;
        public readonly SpriteRenderer SpriteRenderer;
        public readonly Rigidbody2D Rigidbody;
        public readonly Collider2D Collider;
        public readonly int ID;
        private readonly GameObject _player;

        public PlayerInitialization(IFactory factory)
        {
            _player = factory.Create();
            Transform = _player.transform;
            SpriteRenderer = _player.GetComponentInChildren<SpriteRenderer>();
            Collider = _player.GetOrAddComponent<Collider2D>();
            Rigidbody = _player.GetOrAddComponent<Rigidbody2D>();
            ID = _player.GetInstanceID();
        }
    }
}
