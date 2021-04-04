// using UnityEngine;
//
// namespace Asteroids
// {
//     public class InputAttackControllerProxy : IAttack
//     {
//         private IAttack _attack;
//         private AttackLock _attackLock;
//
//         public InputAttackControllerProxy(IAttack attack, AttackLock attackLock)
//         {
//             _attack = attack;
//             _attackLock = attackLock;
//         }
//         
//         public void Shoot(Transform shotPoint)
//         {
//             if (_attackLock.IsUnlock)
//             {
//                 _attack.Shoot(shotPoint);
//             }
//             else
//             {
//                 Debug.Log("Attack is lock");
//             }
//         }
//     }
// }
