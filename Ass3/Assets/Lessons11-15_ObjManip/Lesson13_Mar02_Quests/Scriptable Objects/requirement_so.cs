using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "RequirementSO", menuName = "Quest System/RequirementSO")]
public abstract class requirement_so : ScriptableObject
{
    public string requirementName;
    public abstract requirement_data CreateRuntimeData();
}
