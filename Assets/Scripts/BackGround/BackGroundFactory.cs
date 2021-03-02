using UnityEngine;

namespace Platformer
{
    internal class BackGroundFactory : IBackGroundFactory
    {
        private BackGroundConfig _config;
        private Transform _parentRoot;
        private ICamera _camera;

        public BackGroundFactory(BackGroundConfig config, Transform parent, ICamera camera)
        {
            _config = config;
            _parentRoot = parent;
            _camera = camera;
        }

        public ParalaxBackGround Create()
        {
            var back = Object.Instantiate(_config.BackGround, _parentRoot.transform);

            back = _config.IsPlaceChanging ? ChangePosition(back, _config.SizeCoefficient) : 
                   _config.IsSizeChanging ? ChangeSize(back, _config.SizeCoefficient) : back;

            return new ParalaxBackGround(_camera, back.transform, _config);
        }

        private GameObject ChangePosition(GameObject back, float delta)
        {
            foreach (Transform child in back.transform)
            {
                float randomSize = Random.Range(1.0f, delta);
                child.transform.localScale = new Vector3(randomSize, randomSize, 1.0f);
            }

            return back;
        }

        private GameObject ChangeSize(GameObject back, float delta)
        {
            foreach (Transform child in back.transform)
            {
                child.transform.position = GetRandomVector(child.transform.position, delta);
            }

            return back;
        }

        private Vector3 GetRandomVector(Vector3 vector, float delta)
        {
            var newVector = new Vector3(vector.x + Random.Range(-1.0f * delta, delta),
                vector.y + Random.Range(-1.0f * delta, delta), vector.z);
            return newVector;
        }
    }
}
