using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIThinker : MonoBehaviour
{
    public State currentState;
    public State remainState;

    public TargetObject targetObject;
    public Transform playerTarget;

    public float chaseSpeed;

    public float rotationSmooth;
    [HideInInspector]
    public float currSmoothVelocity;
    [HideInInspector]
    public Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState != null)
        {
            currentState.UpdateState(this);
        }
    }

    public void TransitionToState(State state)
    {
        if(state != remainState)
        {
            currentState = state;
        }
    }
}
