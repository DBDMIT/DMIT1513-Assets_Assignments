using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class requirement_updater : MonoBehaviour
{
    public enum UpdateType
    {
        SetBool,
        IncrementInt
    }

    [Serializable]
    public class RequirementUpdate
    {
        public requirement_so requirementSO;
        public UpdateType updateType;
        public int increment = 1;
        public bool boolVal = true;
    }

    [SerializeField] private RequirementUpdate[] requirementUpdates;

    private void Start()
    {
        if(goal_manager.instance == null)
        {
            Debug.LogError("Goal manager is not in scene");
            return;
        }
    }

    public void UpdateRequirement()
    {
        if (goal_manager.instance == null)
        {
            Debug.LogError("Goal manager is not in scene");
            return;
        }

        foreach (var update in requirementUpdates)
        {
            switch (update.updateType)
            {
                case UpdateType.SetBool:
                    if (update.requirementSO is bool_requirement_so boolReq)
                    {
                        goal_manager.instance.SetBoolRequirement(boolReq, update.boolVal);
                    }
                    break;
                case UpdateType.IncrementInt:
                    if(update.requirementSO is int_requirement_so intReq)
                    {
                        goal_manager.instance.SetIntRequirement(intReq, update.increment);
                    }
                    break;
            }
        }
    }
}
