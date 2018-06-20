using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomBehaviorTree;

public class Deneme : MonoBehaviour
{
    IBehaviorTreeNode tree;

    void Start()
    {
        BehaviorTreeBuilder builder = new BehaviorTreeBuilder();

        builder.Sequence("sequence1");
        builder.Action("action1", Action01);
        builder.Action("action2", Action02);
        builder.Sequence("sequence02");
        builder.Action("action03", Action03);
        builder.Action("action04", Action04);
        builder.End();
        builder.Action("Action05", Action05);
        builder.Action("Action06", Action06);
        builder.End();
        tree = builder.Build();
    }

    float time = 0f;

    private void Update()
    {
        tree.Tick(new TimeData(Time.deltaTime));
    }

    float m_time = 0f;

    BehaviorTreeStatus Action01(TimeData time)
    {
        Debug.Log("Action01");
        return BehaviorTreeStatus.SUCCESS;
    }

    BehaviorTreeStatus Action02(TimeData time)
    {
        Debug.Log("Action02");
        return BehaviorTreeStatus.SUCCESS;
    }

    BehaviorTreeStatus Action03(TimeData time)
    {
        Debug.Log("Action03");
        return BehaviorTreeStatus.RUNNING;
    }

    BehaviorTreeStatus Action04(TimeData time)
    {
        Debug.Log("Action04");
        return BehaviorTreeStatus.SUCCESS;
    }

    BehaviorTreeStatus Action05(TimeData time)
    {
        Debug.Log("Action05");
        return BehaviorTreeStatus.SUCCESS;
    }

    BehaviorTreeStatus Action06(TimeData time)
    {
        Debug.Log("Action06");
        return BehaviorTreeStatus.SUCCESS;
    }


}
