using UnityEngine;

namespace Platformer
{
    internal class MaceController
    {
        private HingeJoint2D _joint;
        private ITimeRemaining _timeRemaining;

        public MaceController(GameObject mace)
        {
            _joint = mace.GetComponent<HingeJoint2D>();
            AddMotorForce();
            _timeRemaining = new TimeRemaining(AddMotorForce, 4.4f, true);
            _timeRemaining.AddTimeRemaining();
        }

        private void AddMotorForce()
        {
            _joint.useMotor = true;
            _timeRemaining = new TimeRemaining(StopMotorForce, 0.1f, false);
            _timeRemaining.AddTimeRemaining();
        }

        private void StopMotorForce()
        {
            _joint.useMotor = false;
        }
    }
}
