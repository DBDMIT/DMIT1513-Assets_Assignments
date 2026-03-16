using System;
using System.Collections.Generic;
using UnityEngine;

public class quest_data
{
    public Dictionary<goal_so, goal_data> goals = new();

    public string questName;
    public bool isComplete = false;
    public bool isActive = false;
    public quest_so Config;
    public int initialGoalID = 0;
    public int completedGoals;

    public event Action<quest_data> onQuestUpdated;
    public event Action<quest_data> onQuestCompleted;

    public quest_data(quest_so Config_)
    {
        Config = Config_;
        completedGoals = 0;
        initialGoalID = Config.initialGoalID;
        questName = Config.questName;

        foreach (goal_so goalConfig in Config.goals)
        {
            goal_data tmp = new goal_data(goalConfig);
            goals.Add(goalConfig, tmp);

            tmp.onGoalUpdated += GoalUpdated;
            tmp.onGoalComplete += GoalComplete;
        }
    }

    public void GoalComplete(goal_data goal)
    {
        completedGoals++;
        if (completedGoals >= goals.Values.Count)
        {
            onQuestCompleted?.Invoke(this);
        }
    }

    public void GoalUpdated(goal_data goal)
    {
        goals[goal.config] = goal;
        onQuestUpdated?.Invoke(this);
    }

    public void ActivateQuest()
    {
        isActive = true;
        onQuestUpdated.Invoke(this);
    }

    public void ActivateGoal(goal_so goal)
    {
        goals[goal].ActivateGoal();
    }
}
