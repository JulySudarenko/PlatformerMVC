

namespace Platformer
{
    public sealed class SwitchQuestModel : IQuestModel
    {
        private readonly int _targetID;

        public SwitchQuestModel(int targetID)
        {
            _targetID = targetID;
        }

        public bool TryComplete(int activator)
        {
            return activator == _targetID;
        }
    }
}
