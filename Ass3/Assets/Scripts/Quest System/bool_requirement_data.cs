using UnityEngine;

public class bool_requirement_data : requirement_data
{
    private bool defaultValue;
    private bool value_;

    public bool value
    {
        get => value_;
        set
        {
            value_ = value;
            RaiseRequirementChanged();
        }
    }
    public bool_requirement_data(bool_requirement_so Config_)
    {
        Config = Config_;
        value = Config_.defaultValue;
        defaultValue = Config_.defaultValue;
    }
    public override bool IsMet()
    {
        return value;
    }

    public override void Reset()
    {
        value = defaultValue;
    }
}
