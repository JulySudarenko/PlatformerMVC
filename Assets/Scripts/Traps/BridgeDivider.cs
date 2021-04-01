using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    internal class BridgeDivider : IInitialize, IExecute, ICleanup
    {
        private List<DistanceJoint2D> _joints;
        private Transform _bridge;
        private TriggerContacts _contacts;
        private int _contactCounter = 0;
        private int _breakBridgeContact = 2;
        private readonly int _contactID;
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
            if (!_hasDestroyed)
            {
                if (_contactCounter > _breakBridgeContact)
                {
                    BreakBridge();
                    _hasDestroyed = true;
                }
            }
        }

        public void Cleanup()
        {
            _contacts.IsContact -= CountContacts;
        }
    }
}
