using UnityEngine;
using UnityEngine.Events;

public class GoalEventListener : MonoBehaviour
{
    public int targetGoal;
    public UnityEvent OnGoalComplete;

    private void Start()
    {
        goal_manager.instance.onGoalComplete += GoalComplete;
    }

    public void GoalComplete(goal_data goalData)
    {
        if(goalData.goalID != targetGoal)
        {
            return;
        }
        OnGoalComplete?.Invoke();
    }

}
