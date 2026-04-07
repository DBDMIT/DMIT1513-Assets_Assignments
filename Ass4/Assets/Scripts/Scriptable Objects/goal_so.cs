using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GoalSO", menuName = "Quest System/GoalSO")]
public class goal_so : ScriptableObject
{
    public List<requirement_so> requirements;
    public string goalName;
    public int goalID;
    public int nextGoalID;
}
