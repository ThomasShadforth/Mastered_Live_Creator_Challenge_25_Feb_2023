using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Check Player Distance Decision", menuName = "PluggableAI/Decisions/Check Player Distance")]
public class CheckPlayerRangeDecision : Decision
{
    public override bool Decide(AIThinker thinker)
    {
        bool canSteal = CheckDistanceToPlayer(thinker);
        return canSteal;
    }

    bool CheckDistanceToPlayer(AIThinker thinker)
    {
        if(Vector3.Distance(thinker.transform.position, thinker.playerTarget.position) <= thinker.stealRange)
        {
            thinker.playerTarget.GetComponentInChildren<TargetObject>().PickupObject(thinker.handPosition);
            thinker.playerTarget.GetComponent<PlayerGrab>().isGrabbing = false;
            return true;
        }
        else
        {
            return false;
        }
    }
}
