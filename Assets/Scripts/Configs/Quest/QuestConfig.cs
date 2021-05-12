using UnityEngine;

[CreateAssetMenu(menuName = "QuestConfig", fileName = "Configs/QuestConfig", order = 0)]
public class QuestConfig : ScriptableObject
{
    public int id;
    public QuestType questType;
}

public enum QuestType
{
    Switch,
}

