using System.Collections.Generic;
using UnityEngine;
using static Platformer.NameManager;

namespace Platformer
{
    internal class ParalaxController : IInitialize, IExecute
    {
        private ICamera _camera;
        private BackGroundConfig[] _back;
        private ParalaxBackGround[] _managers;
        private List<Transform> _coinsPlaces { get; }
        private GameObject _root;

        public ParalaxController(ICamera camera, BackGroundConfig[] data)
        {
            _camera = camera;
            _back = data;
            _managers = new ParalaxBackGround[data.Length];
            _root = new GameObject(BACKGROUND_ROOT);
        }

        public void Initialize()
        {
            for (int i = 0; i < _back.Length; i++)
            {
                 var backParalax = new BackGroundInitialisation(new BackGroundFactory(_back[i], _root.transform, _camera));
                 _managers[i] = backParalax.GetParalaxBackGround();
            }
        }

        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _managers.Length; i++)
            {
                _managers[i].Execute();
            }
        }
    }
}
