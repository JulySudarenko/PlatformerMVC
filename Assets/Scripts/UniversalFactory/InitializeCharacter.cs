using UnityEngine;

namespace Platformer
{
    internal class InitializeCharacter
    {
        public readonly Transform Transform;
        public readonly SpriteRenderer SpriteRenderer;
        public readonly Rigidbody2D Rigidbody;
        public readonly Collider2D Collider;
        public readonly Hit HitInfo;
        public readonly int ID;

        public InitializeCharacter(IFactory factory)
        {
            var enemy = factory.Create();
            Transform = enemy.transform;
            SpriteRenderer = enemy.GetComponentInChildren<SpriteRenderer>();
            Collider = enemy.GetOrAddComponent<Collider2D>();
            Rigidbody = enemy.GetOrAddComponent<Rigidbody2D>();
            HitInfo = enemy.GetOrAddComponent<Hit>();
            ID = enemy.GetInstanceID();
        }
    }
}
