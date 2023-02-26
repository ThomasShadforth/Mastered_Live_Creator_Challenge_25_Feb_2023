using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Check Object Distance Decision", menuName = "PluggableAI/Decisions/Check Object Distance")]
public class CheckObjectRangeDecision : Decision
{
    public override bool Decide(AIThinker thinker)
    {
        bool canPickUp = CheckDistanceToObject(thinker);
        return canPickUp;
    }

    bool CheckDistanceToObject(AIThinker thinker)
    {
        if(Vector3.Distance(thinker.transform.position, thinker.targetObject.transform.position) <= thinker.grabRange)
        {
            thinker.targetObject.PickupObject(thinker.handPosition);

            return true;
        }
        else
        {
            return false;
        }
        
    }
}
