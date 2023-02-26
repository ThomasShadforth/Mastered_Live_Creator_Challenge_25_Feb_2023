using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Check Object Base Distance Decision", menuName = "PluggableAI/Decisions/Check Base Distance")]
public class CheckDistanceToBaseDecision : Decision
{
    public override bool Decide(AIThinker thinker)
    {
        bool reachedBase = CheckDistanceToBase(thinker);
        return reachedBase;
    }

    bool CheckDistanceToBase(AIThinker thinker)
    {
        Debug.Log(Vector3.Distance(thinker.transform.position, thinker._base.transform.position));

        if(Vector3.Distance(thinker.transform.position, thinker._base.transform.position) < 3f)
        {
            thinker.targetObject.transform.SetParent(null);
            thinker.targetObject.gameObject.SetActive(false);
            return true;
        }
        else
        {
            return false;
        }

        
    }
}
