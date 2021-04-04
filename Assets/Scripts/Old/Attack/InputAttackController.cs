// using UnityEngine;
// using static Asteroids.AxisManager;
// using static Asteroids.NameManager;
//
// namespace Asteroids
// {
//     public class InputAttackController : IAttack
//     {
//         private BulletPool _bulletPool;
//         private ITimeRemaining _timeRemaining;
//         private IForce _force;
//
//         public InputAttackController(BulletFactory bulletFactory, IForce force, IPoolSize poolSize,
//             ContactCenter contactCenter)
//         {
//             _force = force;
//             _bulletPool = new BulletPool(bulletFactory, poolSize.PoolSize, contactCenter);
//         }
//
//         public void Shoot(Transform shotPoint)
//         {
//             if (Input.GetButtonDown(FIRE))
//             {
//                 var bullet = _bulletPool.GetBullet(NAME_AMMUNITION);
//                 bullet.gameObject.AddTransform(shotPoint);
//                 bullet.gameObject.SetActive(true);
//                 bullet.AddForce(shotPoint.up * _force.Force);
//             }
//         }
//     }
// }
