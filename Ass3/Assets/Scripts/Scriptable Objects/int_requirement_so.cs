using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "IntRequirementSO", menuName = "Quest System/IntRequirementSO")]
public class int_requirement_so : requirement_so
{
    public int defaultValue;
    public int targetValue;

    public override requirement_data CreateRuntimeData()
    {
        return new int_requirement_data(this);
    }
}
