using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGrab : MonoBehaviour
{
    [SerializeField] Transform _playerHand;
    PlayerActionMap _input;
    public bool isGrabbing;
    public float grabRange;
    public float stealRange;

    // Start is called before the first frame update
    void Start()
    {
        _input = new PlayerActionMap();
        _input.Player.PickUp.Enable();
        _input.Player.PickUp.performed += PickupObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PickupObject(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!isGrabbing) {
                //Debug.Log("PICKUP OBJECT");

                TargetObject[] objects = FindObjectsOfType<TargetObject>();
                if(objects.Length != 0)
                {
                    TargetObject objectToGrab = objects[0];

                    for(int i = 1; i < objects.Length; i++)
                    {
                        if(Vector3.Distance(transform.position, objects[i].transform.position) < Vector3.Distance(transform.position, objectToGrab.transform.position))
                        {
                            objectToGrab = objects[i];
                        }
                    }

                    //Debug.Log("DISTANCE TO OBJECT: " + Vector3.Distance(transform.position, objectToGrab.transform.position));

                    if(Vector3.Distance(transform.position, objectToGrab.transform.position) < grabRange)
                    {
                        //Debug.Log("IN GRAB RANGE");
                        objectToGrab.hasBeenPickedUp = true;
                        objectToGrab.PickupObject(_playerHand);
                        
                        isGrabbing = true;
                    }
                }

                AIThinker[] AI = FindObjectsOfType<AIThinker>();

                if(AI.Length != 0)
                {
                    AIThinker AIToStealFrom = AI[0];

                    for(int i = 1; i < AI.Length; i++)
                    {
                        if (Vector3.Distance(transform.position, AI[i].transform.position) < Vector3.Distance(transform.position, AI[i].transform.position))
                        {
                            AIToStealFrom = AI[i];
                        }
                    }

                    if (Vector3.Distance(transform.position, AIToStealFrom.transform.position) < stealRange)
                    {
                        if (AIToStealFrom.GetComponentInChildren<TargetObject>())
                        {
                            AIToStealFrom.GetComponentInChildren<TargetObject>().PickupObject(_playerHand);
                        }
                    }
                }


            }
        }
    }
}
