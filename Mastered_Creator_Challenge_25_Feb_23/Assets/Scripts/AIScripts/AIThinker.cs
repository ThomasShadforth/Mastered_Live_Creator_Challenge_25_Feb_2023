using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIThinker : MonoBehaviour
{
    public State currentState;
    public State remainState;

    public TargetObject targetObject;
    public Transform playerTarget;
    public Transform handPosition;

    [Header("Movement Config:")]
    public float chaseSpeed;

    [Header("Object Grabbing Config:")]
    public float grabRange;
    public float stealRange;

    [Header("Rotation Config:")]
    public float rotationSmooth;
    [HideInInspector]
    public float currSmoothVelocity;
    [HideInInspector]
    public Rigidbody _rb;
    [HideInInspector]
    public bool initialTargetSet;

    bool stunned = false;
    [HideInInspector]
    public EnemyBase _base;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        _base = FindObjectOfType<EnemyBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_base.gameEnded)
        {
            _rb.velocity = Vector3.zero;
            return;
        }

        if (stunned) return;

        

        if(currentState != null)
        {
            currentState.UpdateState(this);
        }
    }

    public void StunAI()
    {
        stunned = true;
        StartCoroutine(StunCo());
    }

    

    public void TransitionToState(State state)
    {
        if(state != remainState)
        {
            currentState = state;
        }
    }

    IEnumerator StunCo()
    {
        yield return new WaitForSeconds(.75f);
        stunned = false;
    }
}
