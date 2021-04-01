using Platformer;
using UnityEngine;

namespace PlatformerMVC
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
