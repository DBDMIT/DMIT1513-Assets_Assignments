using UnityEngine;

public class int_requirement_data : requirement_data
{
    public int currentValue;
    public int targetValue;

    public int_requirement_data(int_requirement_so Config_)
    {
        Config = Config_;
        currentValue = Config_.defaultValue;
        targetValue = Config_.targetValue;
    }

    public override bool IsMet()
    {
        bool val = currentValue >= targetValue;
        return val;
    }

    public override void Reset()
    {
        currentValue = 0;
    }

    public void Increment(int amt)
    {
        currentValue += amt;
        RaiseRequirementChanged();
    }
}
