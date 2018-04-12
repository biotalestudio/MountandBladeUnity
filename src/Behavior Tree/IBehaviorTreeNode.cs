using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomBehaviorTree
{
    public interface IBehaviorTreeNode
    {
        BehaviorTreeStatus Tick(TimeData deltaTime);
    }
}
