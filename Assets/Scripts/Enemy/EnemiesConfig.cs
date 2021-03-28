using Pathfinding;
using System;
using UnityEngine;


namespace Platformer
{
    public class EnemiesConfig : MonoBehaviour
    {
        [Header("Simple AI")] 
        [SerializeField] private AIConfig _simplePatrolAIConfig;
        [SerializeField] private LevelObjectView _simplePatrolAIView;
        [SerializeField] private AnimationData _animationData;

        [Header("Stalker AI")]
        [SerializeField] private AIConfig _stalkerAIConfig;

        [SerializeField] private LevelObjectView _stalkerAIView;

        [SerializeField] private Seeker _stalkerAISeeker;
        [SerializeField] private Transform _stalkerAITarget;

        [Header("Protector AI")] [SerializeField]
        private LevelObjectView _protectorAIView;

        [SerializeField] private AIDestinationSetter _protectorAIDestinationSetter;

        //[SerializeField] private AIPatrolPath _protectorAIPatrolPath;
        // [SerializeField] private LevelObjectTrigger _protectedZoneTrigger;
        [SerializeField] private Transform[] _protectorWaypoints;

        private SimplePatrolAI _simplePatrolAI;

        //private StalkerAI _stalkerAI;

        // private ProtectorAI _protectorAI;
        // private ProtectedZone _protectedZone;

        private void Start()
        {
            _simplePatrolAI = new SimplePatrolAI(_simplePatrolAIView, new SimplePatrolAIModel(_simplePatrolAIConfig),
                _animationData.BatEnemyAnimatorCnf);

            //_stalkerAI = new StalkerAI(_stalkerAIView, new StalkerAIModel(_stalkerAIConfig), _stalkerAISeeker, _stalkerAITarget);
            //InvokeRepeating(nameof(RecalculateAIPath), 0.0f, 1.0f);

            //
            // _protectorAI = new _protectorAI(_protectorAIView, new PatrolAIModel(_protectorWaypoints),
            //     _protectorAIDestinationSetter, _pro); 
            // _protectorAI.Init();
            //     
            // _protectedZone = new _protectedZone(_protectedZoneTrigger, new List<IProtector> {_protectorAI});
            // _protectedZone.Init();
            // }
            //
            // private void FixedUpdate()
            // {
            // if (_simplePatrolAI != null) _simplePatrolAI.FixedExecute(Time.fixedDeltaTime);
            // if (_stalkerAI != null) _stalkerAI.FixedExecute(Time.fixedDeltaTime);
            //     
            //   AstarPath.active.Scan();
        }

        // private void OnDestroy()
        // {
        //     _protectorAI.Deinit();
        //     _protectedZone.Deinit();
        // }
        //
        // private void RecalculateAIPath()
        // {
        //     _stalkerAI.RecalculatePath();
        // }
    }
}
