using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Check Object Decision", menuName = "PluggableAI/Decisions/Check Object")]
public class CheckObjectStateDecision : Decision
{
    public override bool Decide(AIThinker thinker)
    {
        bool stateChanged = CheckObject(thinker);
        return stateChanged;
    }

    public bool CheckObject(AIThinker thinker)
    {
        if (thinker.targetObject.hasBeenPickedUp)
        {
            return true;
        }
        else
        {
            return false;
        }

        
    }
}
