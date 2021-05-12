using UnityEngine;

namespace Platformer
{
    public class PlayerInitialization
    {
        public readonly Transform Transform;
        public readonly SpriteRenderer SpriteRenderer;
        public readonly Rigidbody2D Rigidbody;
        public readonly Collider2D Collider;
        public readonly TriggerContacts TriggerContacts;
        public readonly Hit Hit;
        public readonly int ID;

        public PlayerInitialization(IFactory factory)
        {
            var player = factory.Create();
            Transform = player.transform;
            SpriteRenderer = player.GetComponentInChildren<SpriteRenderer>();
            Collider = player.GetOrAddComponent<Collider2D>();
            Rigidbody = player.GetOrAddComponent<Rigidbody2D>();
            TriggerContacts = player.GetOrAddComponent<TriggerContacts>();
            Hit = player.GetOrAddComponent<Hit>();
            ID = player.GetInstanceID();
        }
    }

}
