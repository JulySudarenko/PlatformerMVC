// using System;
// using Pathfinding;
// using UnityEngine;
//
// namespace Platformer
// {
//     public class StalkerAI
//     {
//         private readonly LevelObjectView _view;
//         private readonly StalkerAIModel _model;
//         //private readonly Seeker _seeker;
//         private readonly Transform _target;
//
//         // public StalkerAI(LevelObjectView view, StalkerAIModel model, Seeker seeker, Transform target)
//         // {
//         //     _view = view != null ? view : throw new ArgumentNullException(nameof(view));
//         //     _model = model != null ? model : throw new ArgumentNullException(nameof(model));
//         //     _seeker = seeker != null ? seeker : throw new ArgumentNullException(nameof(seeker));
//         //     _target = target != null ? target : throw new ArgumentNullException(nameof(target));
//         // }
//
//         // public void FixedExecute(float deltaTime)
//         // {
//         //     var newVelocity = _model.CalculateVelocity(_view.Transform.position) * deltaTime;
//         //     _view.Rigidbody2D.velocity = newVelocity;
//         // }
//
//         // public void RecalculatePath()
//         // {
//         //     if (_seeker.IsDone())
//         //     {
//         //         _seeker.StartPath(_view.Rigidbody2D.position, _target.position, OnPathComplete);
//         //     }
//         // }
//
//         // private void OnPathComplete(Path path)
//         // {
//         //     if(path.error) return;
//         //     _model.UpdatePath(path);
//         // }
//     }
// }
