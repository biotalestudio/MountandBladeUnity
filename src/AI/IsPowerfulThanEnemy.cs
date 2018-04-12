using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class IsPowerfulThanEnemy : Conditional
{
    public SharedGameObject enemy;

    private Party m_party;
    private PartyScript m_partyScript;

    private Party m_enemyParty;
    private PartyScript m_enemyScript;

    public override void OnStart()
    {
        m_partyScript = GetComponent<PartyScript>();
        m_party = m_partyScript.party;

        m_enemyScript = enemy.Value.GetComponent<PartyScript>();
        m_enemyParty = m_enemyScript.party;
    }

    bool IsPowerful()
    {
        if (m_party.PartyValue > m_enemyParty.PartyValue)
            return true;
        else
            return false;
    }

    public override TaskStatus OnUpdate()
    {
        if (IsPowerful())
            return TaskStatus.Success;
        else
            return TaskStatus.Failure;
    }
}
