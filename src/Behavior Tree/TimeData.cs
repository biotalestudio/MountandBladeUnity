using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomBehaviorTree
{
    public struct TimeData
    {
        public float deltaTime;

        public TimeData(float deltaTime)
        {
            this.deltaTime = deltaTime;
        }
    }
}
