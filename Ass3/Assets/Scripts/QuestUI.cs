using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUI : MonoBehaviour
{
    public TMP_Text questName;
    public TMP_Text goalName;
    public Slider questProgress;

    public void Start()
    {
        quest_manager.instance.onQuestUpdate += QuestUpdated;
    }

    public void QuestUpdated(quest_data data)
    {
        questName.text = data.questName;
        questProgress.value = (float)data.completedGoals / (float)data.goals.Values.Count;
        foreach(goal_data goal in data.goals.Values)
        {
            if (goal.isActive == true)
            {
                goalName.text = goal.goalName;
            }
           
        }
    }
}
