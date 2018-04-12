using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomBehaviorTree
{
    public class ActionNode : IBehaviorTreeNode
    {
        private string m_name;

        private Func<TimeData, BehaviorTreeStatus> m_function;

        public ActionNode(string name, Func<TimeData, BehaviorTreeStatus> function)
        {
            m_name = name;
            m_function = function;
        }
        
        public BehaviorTreeStatus Tick(TimeData time)
        {
            return m_function(time);
        }
    }
}
