using UnityEngine;

namespace Platformer
{
    internal class PlayerInitialization
    {
        public Transform Transform;
        public SpriteRenderer SpriteRenderer;
        public Rigidbody2D Rigidbody;
        public Collider2D Collider;
        private GameObject _player;

        public PlayerInitialization(IPlayerFactory factory)
        {
            _player = factory.Create();
            Transform = _player.transform;
            SpriteRenderer = _player.GetComponentInChildren<SpriteRenderer>();
            Collider = _player.GetOrAddComponent<Collider2D>();
            Rigidbody = _player.GetOrAddComponent<Rigidbody2D>();
        }
    }
}
