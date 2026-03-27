using System.Collections.Generic;
using UnityEngine;

public class requirement_manager : MonoBehaviour
{
    public Dictionary<requirement_so, requirement_data> requirements;
    public static requirement_manager instance;

    private void Awake()
    {
        instance = this;
    }

    public void TrackGoal(goal_data goal)
    {
        requirements = goal.requirements;
        foreach (requirement_data req in requirements.Values)
        {
            req.onRequirementUpdated += RequirementUpdated;
        }
    }

    public void RequirementUpdated(requirement_data req)
    {
        Debug.Log("Requirement " + req + " updated");
        requirements[req.Config] = req;
    }
}
