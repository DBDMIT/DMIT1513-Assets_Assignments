using System;
using UnityEngine;

public abstract class requirement_data
{
    public requirement_so Config { get; protected set; }
    public abstract void Reset();
    public abstract bool IsMet();

    public event Action<requirement_data> onRequirementUpdated;

    protected void RaiseRequirementChanged()
    {
        onRequirementUpdated?.Invoke(this);
    }
}
