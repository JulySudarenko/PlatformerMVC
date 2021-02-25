using UnityEngine;

namespace Platformer
{
    internal class ParalaxController : IInitialize, IExecute
    {
        private ICamera _camera;
        private BackGroundConfig[] _back;
        private ParalaxManager[] _managers;
        private GameObject _root;

        public ParalaxController(ICamera camera, BackGroundConfig[] data)
        {
            _camera = camera;
            _back = data;
            _managers = new ParalaxManager[data.Length];
            _root = new GameObject("root");
        }

        public void Initialize()
        {
            for (int i = 0; i < _back.Length; i++)
            {
                var back = Object.Instantiate(_back[i].BackGround, _root.transform);

                back = _back[i].IsPlaceChanging ? ChangePosition(back, _back[i].SizeCoefficient) : back;
                back = _back[i].IsSizeChanging ? ChangeSize(back, _back[i].SizeCoefficient) : back;

                var paralaxManager = new ParalaxManager(_camera, back.transform, _back[i]);
                _managers[i] = paralaxManager;
            }
        }

        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _managers.Length; i++)
            {
                _managers[i].Execute(deltaTime);
            }
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
            var newVector = new Vector3(vector.x + Random.Range(-1 * delta, delta),
                vector.y + Random.Range(-1 * delta, delta), vector.z);
            return newVector;
        }
    }
}
