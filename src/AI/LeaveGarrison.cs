using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

namespace MBUnity
{
    public class LeaveGarrison : Action
    {
        private PartyScript m_partyScript;

        public override void OnAwake()
        {
            m_partyScript = GetComponent<PartyScript>();
        }
        
        public override TaskStatus OnUpdate()
        {
            m_partyScript.ExitLocation(m_partyScript.GetCurrentLocation());
            return TaskStatus.Success;
        }
    }
}