using UnityEngine;

namespace Platformer
{
    public class ContactPoller
    {
        public bool HasTopContact { get; private set; }
        public bool IsGrounded { get; private set; }
        public bool HasLeftContact { get; private set; }
        public bool HasRightContact { get; private set; }

        private ContactPoint2D[] _contacts = new ContactPoint2D[10];
        private const float _collisiontresh = 0.6f;
        private int _contactCount;
        private readonly Collider2D _collider2D;

        public ContactPoller(Collider2D collider2D)
        {
            _collider2D = collider2D;
        }

        public void Execute(float deltaTime)
        {
            HasTopContact = false;
            IsGrounded = false;
            HasLeftContact = false;
            HasRightContact = false;

            _contactCount = _collider2D.GetContacts(_contacts);
            for (int i = 0; i < _contactCount; i++)
            {
                var normal = _contacts[i].normal;
                var rigidbody = _contacts[i].rigidbody;

                if (normal.y > _collisiontresh) IsGrounded = true;
                if (normal.y < -_collisiontresh) HasTopContact = true;
                if (normal.x > _collisiontresh && rigidbody == null) HasLeftContact = true;
                if (normal.x < -_collisiontresh&& rigidbody == null) HasRightContact = true;
            }
        }
    }
}
