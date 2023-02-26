using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move To Target Action", menuName = "PluggableAI/Actions/Move To Target")]
public class MoveToTargetAction : Action
{
    public override void Act(AIThinker thinker)
    {
        if (!thinker.initialTargetSet)
        {
            SetTarget(thinker);
            thinker.initialTargetSet = true;
        }

        MoveToTarget(thinker);
    }

    void SetTarget(AIThinker thinker)
    {
        TargetObject[] objects = FindObjectsOfType<TargetObject>();

        if(objects.Length != 0)
        {
            TargetObject target = objects[0];

            for(int i = 1; i < objects.Length; i++)
            {
                //if the distance between the AI and an object is less than the set target, then set it as the new target
                if(Vector3.Distance(thinker.transform.position, objects[i].transform.position) < Vector3.Distance(thinker.transform.position, target.transform.position))
                {
                    target = objects[i];
                }
            }

            //Debug.Log(target.gameObject.name);

            thinker.targetObject = target;
        }
    }

    void MoveToTarget(AIThinker thinker)
    {
        Vector3 direction = GetMoveDirection(thinker);

        thinker._rb.velocity = new Vector3(direction.x * thinker.chaseSpeed, thinker._rb.velocity.y, direction.z * thinker.chaseSpeed);

        thinker.transform.rotation = Quaternion.Euler(0, GetRotationTowardTarget(thinker), 0);
    }

    float GetRotationTowardTarget(AIThinker thinker)
    {
        Vector3 lookDirection = Vector3.zero;
        lookDirection = thinker.targetObject.transform.position - thinker.transform.position;

        float targetAngle = Mathf.Atan2(lookDirection.x, lookDirection.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(thinker.transform.eulerAngles.y, targetAngle, ref thinker.currSmoothVelocity, thinker.rotationSmooth);

        return angle;
    }

    Vector3 GetMoveDirection(AIThinker thinker)
    {
        Vector3 direction = Vector3.zero;
        direction = thinker.targetObject.transform.position - thinker.transform.position;
        direction = direction.normalized;

        return direction;
    }
}
