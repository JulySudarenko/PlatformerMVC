using UnityEngine;

[CreateAssetMenu(menuName = "QuestStoryConfig", fileName = "Configs/QuestStoryConfig", order = 0)]
public class QuestStoryConfig : ScriptableObject
{
    public QuestConfig[] quests;
    public QuestStoryType questStoryType;
}

public enum QuestStoryType
{
    Common,
    Resettable
}

