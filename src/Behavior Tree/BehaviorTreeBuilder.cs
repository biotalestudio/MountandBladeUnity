using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomBehaviorTree
{
    public class BehaviorTreeBuilder
    {
        private IBehaviorTreeNode m_currentParentNode = null;

        private Stack<IParentBehaviorTreeNode> m_parentNodeStack = new Stack<IParentBehaviorTreeNode>();

        //Create an Action Node Here

        public BehaviorTreeBuilder Action(string name, Func<TimeData, BehaviorTreeStatus> function)
        {
            if (m_parentNodeStack.Count <= 0)
            {
                throw new ApplicationException("Can't create a leaf node without creating any composite node!");
            }

            var actionNode = new ActionNode(name, function);

            m_parentNodeStack.Peek().AddChild(actionNode);
            
            return this;
        }

        public BehaviorTreeBuilder Sequence(string name)
        {
            var sequenceNode = new SequenceNode(name);

            if (m_parentNodeStack.Count > 0)
            {
                m_parentNodeStack.Peek().AddChild(sequenceNode);
            }

            m_parentNodeStack.Push(sequenceNode);
            return this;
        }

        //Create a Selector Node Here

        //Create an Inverter Node Here

        public IBehaviorTreeNode Build()
        {
            if (m_currentParentNode == null)
            {
                throw new ApplicationException("Can't create a Behavior Tree without any composite node!");
            }

            return m_currentParentNode;
        }

        //Finished building a composite node
        //Removes composite node from the top of parentstacklist
        public BehaviorTreeBuilder End()
        {
            m_currentParentNode = m_parentNodeStack.Pop();
            return this;
        }
    }
}
