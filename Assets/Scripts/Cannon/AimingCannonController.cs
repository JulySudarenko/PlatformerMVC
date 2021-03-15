using UnityEngine;

namespace Platformer
{
    internal class AimingCannonController : IExecute
    {
        private readonly Transform _cannon;
        private readonly Transform _aim;
        private Vector3 _direction;
        private Vector3 _axis;
        private float _angle;

        public AimingCannonController(Transform cannon, Transform aim)
        {
            _cannon = cannon;
            _aim = aim;
        }

        public void Execute(float deltaTime)
        {
            _direction = _aim.position - _cannon.position;
            _angle = Vector3.Angle(Vector3.down, _direction);
            _axis = Vector3.Cross(Vector3.down, _direction);
            _cannon.rotation = Quaternion.AngleAxis(_angle, _axis);
        }
    }
}

