using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Platformer
{
    public sealed class ResettableQuestStory : IQuestStory
    {
        private readonly List<IQuest> _questsCollection;
        private int _currentIndex;

        public ResettableQuestStory(List<IQuest> questsCollection)
        {
            _questsCollection = questsCollection ?? throw new ArgumentNullException(nameof(questsCollection));
            Subscribe();
            ResetQuests();
        }

        private void Subscribe()
        {
            foreach (var quest in _questsCollection)
            {
                quest.Completed += OnQuestCompleted;
            }
        }

        private void Unsubscribe()
        {
            foreach (var quest in _questsCollection)
            {
                quest.Completed -= OnQuestCompleted;
            }
        }

        private void OnQuestCompleted(object sender, IQuest quest)
        {
            var index = _questsCollection.IndexOf(quest);
            if (_currentIndex == index)
            {
                _currentIndex++;
                if (IsDone) Debug.Log("Story done!");
            }
            else
            {
                ResetQuests();
            }
        }

        private void ResetQuests()
        {
            _currentIndex = 0;
            foreach (var quest in _questsCollection)
            {
                quest.Reset();
            }
        }

        public bool IsDone => _questsCollection.All(value => value.IsCompleted);

        public void Dispose()
        {
            Unsubscribe();
            foreach (var quest in _questsCollection)
            {
                quest.Dispose();
            }
        }
    }
}

