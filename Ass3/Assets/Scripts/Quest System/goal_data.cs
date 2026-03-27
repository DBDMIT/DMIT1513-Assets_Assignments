using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class goal_data
{
    public Dictionary<requirement_so, requirement_data> requirements = new();

    public goal_so config;
    public bool isActive;
    public bool isComplete;
    public int goalID;
    public string goalName;
    public int nextGoalID;

    public event Action<goal_data> onGoalComplete;
    public event Action<goal_data> onGoalUpdated;

    public goal_data(goal_so config_)
    {
        config = config_;
        isActive = false;
        goalID = config.goalID;
        nextGoalID = config.nextGoalID;
        goalName = config.goalName;
        
        foreach (requirement_so req in config.requirements)
        {
            requirement_data tmp = req.CreateRuntimeData();
            tmp.onRequirementUpdated += HandleRequirementChange;
            requirements.Add(req, tmp);
        }
    }

    public bool isCompleted()
    {
        isComplete = requirements.Values.All(r => r.IsMet());

        if (isComplete) onGoalComplete?.Invoke(this);
        return isComplete;
    }

    public void ActivateGoal()
    {
        isActive = true;
        onGoalUpdated?.Invoke(this);
    }

    public void HandleRequirementChange(requirement_data req)
    {
        requirements[req.Config] = req;
        onGoalUpdated?.Invoke(this); // handle ui/data refresh

        if (isActive && isCompleted())
        {
            onGoalComplete?.Invoke(this); // only on goal completion.
        }
    }
}
