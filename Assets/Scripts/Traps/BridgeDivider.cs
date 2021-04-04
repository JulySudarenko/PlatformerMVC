using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    internal class BridgeDivider : IInitialize, IExecute, ICleanup
    {
        private const int BREAK_BRIDGE_CONTACT = 2;
        
        private readonly List<DistanceJoint2D> _joints;
        private readonly Transform _bridge;
        private readonly TriggerContacts _contacts;
        private readonly int _contactID;
        
        private int _contactCounter = 0;
        private bool _hasDestroyed;

        public BridgeDivider(GameObject bridge, int contactID)
        {
            _bridge = bridge.transform;
            _hasDestroyed = false;
            _contactID = contactID;
            _joints = new List<DistanceJoint2D>();
            _contacts = bridge.GetOrAddComponent<TriggerContacts>();
            _contacts.IsContact += CountContacts;
        }

        private void CountContacts(int contactID)
        {
            if (contactID == _contactID)
            {
                _contactCounter++;
            }
        }

        public void Initialize()
        {
            foreach (Transform child in _bridge)
            {
                if (child.TryGetComponent<DistanceJoint2D>(out var joint))
                {
                    _joints.Add(joint);
                }
            }
        }

        private void BreakBridge()
        {
            for (int i = 0; i < _joints.Count; i++)
            {
                _joints[i].breakForce = 1;
            }
        }

        public void Execute(float deltaTime)
        {
            if (!_hasDestroyed && _contactCounter > BREAK_BRIDGE_CONTACT)
            {
                BreakBridge();
                _hasDestroyed = true;
            }
        }

        public void Cleanup()
        {
            _contacts.IsContact -= CountContacts;
        }
    }
}
