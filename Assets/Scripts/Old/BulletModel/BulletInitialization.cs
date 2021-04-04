// using UnityEngine;
//
//
// namespace Asteroids
// {
//     public class BulletInitialization
//     {
//         private IBulletFactory _bulletFactory;
//
//         public BulletInitialization(IBulletFactory bulletFactory)
//         {
//             _bulletFactory = bulletFactory;
//         }
//
//         public Rigidbody2D GetBullet()
//         {
//             var bullet = _bulletFactory.CreateBullet().GetComponent<Rigidbody2D>();
//             return bullet;
//         }
//     }
// }
