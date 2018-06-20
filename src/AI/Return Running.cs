using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class ReturnRunning : Action
{
    public override TaskStatus OnUpdate()
    {
        Debug.Log("Debug3");
        return TaskStatus.Running;
    }
}
