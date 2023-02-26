using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "State", menuName = "PluggableAI/State")]
public class State : ScriptableObject
{
    public Action[] actions;
    public Transition[] transitions;

    public void UpdateState(AIThinker thinker)
    {
        ExecuteActions(thinker);
        CheckTransitions(thinker);
    }

    void ExecuteActions(AIThinker thinker)
    {
        for(int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(thinker);
        }
    }

    void CheckTransitions(AIThinker thinker)
    {
        for(int i = 0; i < transitions.Length; i++)
        {
            bool succeededTransition = transitions[i].decision.Decide(thinker);

            if (succeededTransition)
            {
                //Use the true state to transition to a new state
                thinker.TransitionToState(transitions[i].trueState);
            }
            else
            {
                thinker.TransitionToState(transitions[i].falseState);
            }
        }
    }
}
