using UnityEngine;

namespace Platformer
{
    internal class GenerateLevelEntryPointController : MonoBehaviour
    {
        private Controllers _controllers;

        private void Awake()
        {
            
            _controllers = new Controllers();
        }


        private void Start()
        {
            _controllers.Initialize();
        }

        private void Update()
        {
            _controllers.Execute(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _controllers.FixedExecute(Time.fixedDeltaTime);
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
        }
    }
}
