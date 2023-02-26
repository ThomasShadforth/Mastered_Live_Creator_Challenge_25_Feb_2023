using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObject : MonoBehaviour
{
    public bool hasBeenPickedUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickupObject(Transform parentTransform)
    {
        //Todo: Implement rigidbody + physical collider, disable on pickup (Or have player and AI ignore the colliders for the objects)
        hasBeenPickedUp = true;
        transform.SetParent(parentTransform);
        transform.position = parentTransform.position;
        transform.rotation = Quaternion.identity;
    }

    public void DropObject()
    {
        //Drop the object
    }
}
