using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Check Object Stolen Decision", menuName = "PluggableAI/Decisions/Check Object Stolen")]
public class CheckObjectStolenDecision : Decision
{
    public override bool Decide(AIThinker thinker)
    {
        bool objectStolen = CheckObjectPossession(thinker);

        return objectStolen;
    }

    bool CheckObjectPossession(AIThinker thinker)
    {
        if (!thinker.GetComponentInChildren<TargetObject>())
        {
            thinker.StunAI();
            return true;
        }
        else
        {
            return false;
        }
    }
}
