using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "QuestSO", menuName = "Quest System/QuestSO")]
public class quest_so : ScriptableObject
{
    public string questName;
    public List<goal_so> goals;
    public int initialGoalID;
}
