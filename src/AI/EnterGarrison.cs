using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

namespace MBUnity
{
    public class EnterGarrison : Action
    {
        public Location location;

        private PartyScript m_partyScript;

        public override void OnAwake()
        {
            m_partyScript = GetComponent<PartyScript>();
        }

        public override TaskStatus OnUpdate()
        {
            m_partyScript.EnterLocation(location);
            return TaskStatus.Success;
        }
    }

}