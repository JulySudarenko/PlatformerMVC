
namespace Platformer
{
    internal class EnemySimpleController : IInitialize, IFixedExecute
    {
        private EnemyConfig _config;
        private SimplePatrolAI _simplePatrolAI;
        private AnimationData _animationData;

        public EnemySimpleController(EnemyConfig config)
        {
            _config = config;
        }
        
        public void Initialize()
        {
            _simplePatrolAI = new SimplePatrolAI(_config, new SimplePatrolAIModel(_config));
            _simplePatrolAI.Initialize();
        }

        public void FixedExecute(float deltaTime)
        {
            if (_simplePatrolAI != null) _simplePatrolAI.FixedExecute(deltaTime);
        }
    }
}
