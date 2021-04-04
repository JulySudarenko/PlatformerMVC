// using UnityEngine;
// using static Asteroids.NameManager;
//
//
// namespace Asteroids
// {
//     public class BulletFactory : IBulletFactory
//     {
//         private BulletData _bulletData;
//         private const float _mass = 1.0f;
//
//         public BulletFactory(BulletData bulletData)
//         {
//             _bulletData = bulletData;
//         }
//         
//         public GameObject CreateBullet()
//         {
//             return new GameObject(NAME_AMMUNITION)
//                 .AddSprite(_bulletData.BulletSprite)
//                 .AddTrackingSystem()
//                 .AddCircleCollider2D()
//                 .AddRigidbody2D(_mass);
//         }
//     }
// }
