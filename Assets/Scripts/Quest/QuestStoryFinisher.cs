using Platformer;
using UnityEngine;

namespace Platformer
{
    internal class QuestStoryFinisher : IQuestStoryFinisher
    {
        private readonly GameObject _finishLevel;

        public QuestStoryFinisher(TriggerContacts finishLevel)
        {
            _finishLevel = finishLevel.gameObject;
            _finishLevel.SetActive(false);
        }
    
        public void FinishQuestStory()
        {
            _finishLevel.SetActive(true);
        }
    }
}
