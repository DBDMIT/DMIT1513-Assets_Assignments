using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ui_quest : MonoBehaviour
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

        if (questProgress.value == 3)
        {
            questName.text = "YAY, YOU DID IT!";
            questProgress.value += 1;
            goalName.text = "Now get out of here.";
        }

        foreach(goal_data goal in data.goals.Values)
        {
            if (goal.isActive == true)
            {
                goalName.text = goal.goalName;
            }
        }
    }
}
