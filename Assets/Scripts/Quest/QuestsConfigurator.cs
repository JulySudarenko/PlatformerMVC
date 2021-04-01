using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Platformer;

namespace PlatformerMVC
{
    public class QuestsConfigurator : IInitialize, ICleanup
    {
        private readonly QuestObjectView _singleQuestView;
        private readonly QuestStoryConfig[] _questStoryConfigs;
        private readonly QuestObjectView[] _questObjects;
        private readonly Dictionary<QuestType, Func<IQuestModel>> _questFactories;
        private readonly Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>> _questStoryFactories;
        private List<IQuestStory> _questStories;
        private Quest _singleQuest;
        private readonly int _contactID;

        public QuestsConfigurator(QuestObjectView singleQuestView, QuestStoryConfig[] questStoryConfigs,
            QuestObjectView[] questObjects, IQuestStoryFinisher finisher, int contactID)
        {
            _singleQuestView = singleQuestView;
            _questStoryConfigs = questStoryConfigs;
            _questObjects = questObjects;
            _contactID = contactID;
            _questFactories = new Dictionary<QuestType, Func<IQuestModel>>
            {
                {QuestType.Switch, () => new SwitchQuestModel(_contactID)},
            };

            _questStoryFactories = new Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>>
            {
                {QuestStoryType.Common, questCollection => new QuestStory(questCollection, finisher)},
                {QuestStoryType.Resettable, questCollection => new ResettableQuestStory(questCollection)},
            };
        }

        public void Initialize()
        {
            _singleQuest = new Quest(_singleQuestView, new SwitchQuestModel(_contactID));
            _singleQuest.Reset();

            _questStories = new List<IQuestStory>();
            foreach (var questStoryConfig in _questStoryConfigs)
            {
                _questStories.Add(CreateQuestStory(questStoryConfig));
            }
        }

        public void Cleanup()
        {
            foreach (var questStory in _questStories)
            {
                questStory.Dispose();
            }
        
            _questStories.Clear();
        }

        private IQuestStory CreateQuestStory(QuestStoryConfig config)
        {
            var quests = new List<IQuest>();
            foreach (var questConfig in config.quests)
            {
                var quest = CreateQuest(questConfig);
                if (quest == null) continue;
                quests.Add(quest);
            }

            return _questStoryFactories[config.questStoryType].Invoke(quests);
        }

        private IQuest CreateQuest(QuestConfig config)
        {
            var questId = config.id;
            var questView = _questObjects.FirstOrDefault(value => value.Id == config.id);
            if (questView == null)
            {
                Debug.LogWarning($"QuestsConfigurator :: Start : Can't find view of quest {questId.ToString()}");
                return null;
            }

            if (_questFactories.TryGetValue(config.questType, out var factory))
            {
                var questModel = factory.Invoke();
                return new Quest(questView, questModel);
            }

            Debug.LogWarning($"QuestsConfigurator :: Start : Can't create model for quest {questId.ToString()}");
            return null;
        }
    }
}
