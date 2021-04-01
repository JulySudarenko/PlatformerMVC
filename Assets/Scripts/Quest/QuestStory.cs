using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlatformerMVC
{
    public sealed class QuestStory : IQuestStory
    {
        private readonly List<IQuest> _questsCollection = new List<IQuest>();
        private readonly IQuestStoryFinisher _finisher;
        public QuestStory(List<IQuest> questsCollection, IQuestStoryFinisher finisher)
        {
            _questsCollection = questsCollection ?? throw new ArgumentNullException(nameof(questsCollection));
            _finisher = finisher;
            Subscribe();
            ResetQuest(0);
        }

        private void Subscribe()
        {
            foreach (var quest in _questsCollection) quest.Completed += OnQuestCompleted;
        }

        private void Unsubscribe()
        {
            foreach (var quest in _questsCollection) quest.Completed -= OnQuestCompleted;
        }

        private void OnQuestCompleted(object sender, IQuest quest)
        {
            var index = _questsCollection.IndexOf(quest);
            if (IsDone)
            {
                _finisher.FinishQuestStory();
                Debug.Log("Story done!");
            }
            else
            {
                ResetQuest(++index);
            }
        }

        private void ResetQuest(int index)
        {
            if (index < 0 || index >= _questsCollection.Count) return;
            var nextQuest = _questsCollection[index];
            if (nextQuest.IsCompleted) OnQuestCompleted(this, nextQuest);
            else _questsCollection[index].Reset();
        }
        public bool IsDone => _questsCollection.All(value => value.IsCompleted);

        public void Dispose()
        {
            Unsubscribe();
            foreach (var quest in _questsCollection) quest.Dispose();
        }
    }
}
