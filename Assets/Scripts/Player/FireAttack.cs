using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Platformer
{
    internal class FireAttack
    {
        private readonly List<FireBall> _fireBallsController;
        private readonly DamagingObjects _damagingObjects;
        private readonly Pool _fireBallPool;
        private readonly Transform _barrel;
        private readonly Transform _attacker;
        private readonly float _force;
        private readonly float _lifeTime;
        private Vector3 _direction;

        public FireAttack(PlayerConfig config, Transform attacker, DamagingObjects damagingObjects)
        {
            _damagingObjects = damagingObjects;
            _force = config.FireAttackForce;
            _lifeTime = config.FireBallLifeTime;
            _attacker = attacker;
            var shotPoint = new ShotPoint(attacker, config.BarrelPosition);
            _barrel = shotPoint.GetShotPoint();
            _fireBallPool = new Pool(new Factory(config.FireBallPrefab), config.PoolSize, NameManager.FIRE_BALL_ROOT);
            _fireBallsController = new List<FireBall>();
            CreatePool(config.PoolSize);
        }

        public void AttackFire()
        {
            var controlledFireBall = _fireBallsController.FirstOrDefault(a => !a.IsActive);
            if (controlledFireBall == null)
            {
                controlledFireBall = new FireBall(_fireBallPool.GetPoolObject(), _lifeTime, _damagingObjects);
                _fireBallsController.Add(controlledFireBall);
            }
            
            _direction = _barrel.right * _attacker.localScale.x;
            controlledFireBall.Shoot(_barrel.position, _direction * _force);
        }


        private void CreatePool(int poolSize)
        {
            for (int i = 0; i < poolSize; i++)
            {
                _fireBallsController.Add(new FireBall(_fireBallPool.GetPoolObject(), _lifeTime,
                    _damagingObjects));
            }
        }

        public void Cleanup()
        {
            for (int i = 0; i < _fireBallsController.Count; i++)
            {
                _fireBallsController[i].Cleanup();
            }
        }
    }
}
