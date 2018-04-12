using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomBehaviorTree
{
    public class SequenceNode : IParentBehaviorTreeNode
    {
        private string m_name;

        private List<IBehaviorTreeNode> m_childrens = new List<IBehaviorTreeNode>();

        public SequenceNode(string name)
        {
            m_name = name;
        }

        public BehaviorTreeStatus Tick(TimeData deltaTime)
        {
            foreach (var child in m_childrens)
            {
                var childStatus = child.Tick(deltaTime);
                if (childStatus != BehaviorTreeStatus.SUCCESS)
                {
                    return childStatus;
                }
            }

            return BehaviorTreeStatus.SUCCESS;
        }
        
        public void AddChild(IBehaviorTreeNode child)
        {
            m_childrens.Add(child);
        }



    }
}
