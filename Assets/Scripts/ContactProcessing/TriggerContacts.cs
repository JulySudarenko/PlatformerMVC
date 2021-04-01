using System;
using UnityEngine;

namespace Platformer
{
    public class TriggerContacts : MonoBehaviour
    {
        public event Action<int> IsContact;

        private void OnTriggerEnter2D(Collider2D other)
        {
            IsContact?.Invoke(other.gameObject.GetInstanceID());
        }
    }
}
