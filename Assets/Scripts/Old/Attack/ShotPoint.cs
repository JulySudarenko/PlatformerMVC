// using UnityEngine;
// using static Asteroids.NameManager;
//
//
// namespace Asteroids
// {
//     public class ShotPoint
//     {
//         private Transform _parent;
//         private Transform _shotPoint;
//
//         public ShotPoint(Transform parent, IShotPoint shotPoint)
//         {
//             _parent = parent;
//             _shotPoint = shotPoint.ShotPoint;
//         }
//             
//         public Transform GetShotPoint()
//         {
//             var barrel = new GameObject(NAME_SHOT_POINT).AddTransform(_shotPoint);
//             barrel.transform.SetParent(_parent.transform);
//             return barrel.transform;
//         }
//     }
// }
