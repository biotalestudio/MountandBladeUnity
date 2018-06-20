using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomBehaviorTree
{
    public interface IParentBehaviorTreeNode : IBehaviorTreeNode
    {
        void AddChild(IBehaviorTreeNode child);
    }
}
