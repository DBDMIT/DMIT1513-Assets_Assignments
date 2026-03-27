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

    private void OnEnable()
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
                Debug.Log("Set value for req: " + reqData + " to " + reqData.value);
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
                Debug.Log("Activating goal: " + goal.goalID);
                goal.ActivateGoal();
            }
        }
    }

    public void UpdateGoal(goal_data goalData)
    {
        if(goalData.isActive && goalData.isCompleted())
        {
            if (goalData.nextGoalID > -1)
            {
                ActivateGoal(goalData.nextGoalID);
            }
            goalData.isActive = false;
            onGoalComplete?.Invoke(goalData);
            Debug.Log("Goal Complete: " + goalData.goalID);
        }

    
    }

    public void TrackQuest(quest_data questData)
    {
        goalLibrary.AddRange(questData.goals);
        Debug.Log("Tracking Quest: " + questData.questName);
        ActivateGoal(questData.initialGoalID);
    }
}
