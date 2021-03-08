using System;
using UnityEngine;

namespace Platformer
{
    internal class TriggerContacts : MonoBehaviour
    {
        public event Action<GameObject> IsContact;

        private void OnTriggerEnter(Collider other)
        {
            IsContact?.Invoke(other.gameObject);
        }
    }
}
