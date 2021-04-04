using UnityEngine;

namespace Platformer
{
    internal class MaceController : ICleanup
    {
        private readonly HingeJoint2D _joint;
        private readonly ITimeRemaining _timeRemainingAdd;
        private ITimeRemaining _timeRemainingStop;

        public MaceController(GameObject mace, DamagingObjects damagingObjects)
        {
            _joint = mace.GetComponent<HingeJoint2D>();
            AddMotorForce();
            damagingObjects.AddDamagingObject(mace.GetInstanceID());
            _timeRemainingAdd = new TimeRemaining(AddMotorForce, 4.4f, true);
            _timeRemainingAdd.AddTimeRemaining();
        }

        private void AddMotorForce()
        {
            _joint.useMotor = true;
            _timeRemainingStop = new TimeRemaining(StopMotorForce, 0.1f, false);
            _timeRemainingStop.AddTimeRemaining();
        }

        private void StopMotorForce()
        {
            _joint.useMotor = false;
        }


        public void Cleanup()
        {
            _timeRemainingAdd.RemoveTimeRemaining();
            _timeRemainingStop.RemoveTimeRemaining();
        }
    }
}
