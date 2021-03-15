using System;
using UnityEngine;

namespace Platformer
{
    internal class TriggerContacts : MonoBehaviour
    {
        public event Action<GameObject, GameObject> IsContact;

        private void OnTriggerEnter2D(Collider2D other)
        {
            IsContact?.Invoke(gameObject, other.gameObject);
        }
    }
}
