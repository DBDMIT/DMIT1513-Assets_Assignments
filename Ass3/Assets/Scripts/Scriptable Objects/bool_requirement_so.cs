using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BoolRequirementSO", menuName = "Quest System/BoolRequirementSO")]
public class bool_requirement_so : requirement_so
{
    public bool defaultValue;

    public override requirement_data CreateRuntimeData()
    {
        return new bool_requirement_data(this);
    }
}
