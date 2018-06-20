using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MBUnity
{
    //<summary>
    //This action initilaize all the necessary variables before begining of the actual behavior tree
    //It also spawns AI to a begin location
    //</summary>
    public class AIInit : Action
    {
        public SharedGameObject strongestEnemy;
        public SharedVector3 spawnPoint;

        private PartyScript m_partyScript;
        private AIManager m_aiManager;

        public override void OnStart()
        {
            m_partyScript = GetComponent<PartyScript>();
            m_aiManager = GetComponent<AIManager>();

            strongestEnemy = null;

            m_partyScript.TeleportToLocationOwned();
        }

        public override TaskStatus OnUpdate()
        {
            return TaskStatus.Success;
        }
    } 
}
