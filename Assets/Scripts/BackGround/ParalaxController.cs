using System.Collections.Generic;
using UnityEngine;
using static Platformer.NameManager;

namespace Platformer
{
    internal class ParalaxController : IExecute
    {
        private readonly ICamera _camera;
        private readonly BackGroundConfig[] _back;
        private readonly ParalaxBackGround[] _managers;
        public readonly List<TriggerContacts> DeathZones;
        public readonly List<Transform> CoinsPlaces;
        private readonly GameObject _root;

        public ParalaxController(ICamera camera, BackGroundConfig[] data)
        {
            _camera = camera;
            _back = data;
            _managers = new ParalaxBackGround[data.Length];
            _root = new GameObject(BACKGROUND_ROOT);
            DeathZones = new List<TriggerContacts>();
            CoinsPlaces = new List<Transform>();
            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < _back.Length; i++)
            {
                var backParalax =
                    new BackGroundInitialisation(new BackGroundFactory(_back[i], _root.transform, _camera));
                _managers[i] = backParalax.GetParalaxBackGround();
                if (_back[i].IsCoinPlace) ReceiveCoinsPlaces(_managers[i]);
                if (_back[i].IsDeathZone) ReceiveDeathZones(_managers[i]);
            }
        }
        
        public void ReceiveCoinsPlaces(ParalaxBackGround manager)
        {
            var coinsAllPlaces = manager.GetCoinsPlaces();
            for (int i = 0; i < coinsAllPlaces.Count; i++)
            {
                    CoinsPlaces.Add(coinsAllPlaces[i]);
            }
        }
        
        private void ReceiveDeathZones(ParalaxBackGround manager)
        {
            var deathZones = manager.GetDeathZones();
            for (int i = 0; i < deathZones.Count; i++)
            {
                 DeathZones.Add(deathZones[i]);
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
