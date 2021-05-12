using System;
using UnityEngine;

namespace Platformer
{
    public class Hit: MonoBehaviour
    {
        public event Action<int> IsContact;
        private void OnCollisionEnter2D(Collision2D other)
        {
            IsContact?.Invoke(other.gameObject.GetInstanceID());
        }
    }
}
