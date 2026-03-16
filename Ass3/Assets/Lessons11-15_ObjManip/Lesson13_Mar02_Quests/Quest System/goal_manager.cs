using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
public class goal_manager : MonoBehaviour
{
    public Dictionary<goal_so, goal_data> goalLibrary = new();
    public static goal_manager instance;
    public event Action<goal_data> onGoalComplete;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetBoolRequirement(bool_requirement_so requirement, bool newValue)
    {
        foreach(goal_data goalData in goalLibrary.Values)
        {
            if (goalData.isActive == false) continue;
            if (goalData.requirements.TryGetValue(requirement, out requirement_data baseData) && baseData is bool_requirement_data reqData)
            {
                reqData.value = newValue;
            }
        }
    }

    public void SetIntRequirement(int_requirement_so requirement, int increment)
    {
        foreach (goal_data goalData in goalLibrary.Values)
        {
            if (goalData.isActive == false) continue;
            if (goalData.requirements.TryGetValue(requirement, out requirement_data baseData) && baseData is int_requirement_data reqData)
            {
                reqData.Increment(increment);
            }
        }
    }

    public void ActivateGoal(int goalId)
    {
        foreach(goal_data goal in goalLibrary.Values)
        {
            goal.onGoalUpdated += UpdateGoal;

            if (goal.goalID == goalId)
            {
                goal.ActivateGoal();
            }
        }
    }

    public void UpdateGoal(goal_data goalData)
    {
        if(goalData.isActive && goalData.isComplete)
        {
            if (goalData.nextGoalID > -1)
            {
                ActivateGoal(goalData.nextGoalID);
            }
        }

        goalData.isActive = false;
        onGoalComplete(goalData);
    }

    public void TrackQuest(quest_data questData)
    {
        goalLibrary.AddRange(questData.goals);
        ActivateGoal(questData.initialGoalID);
    }
}
