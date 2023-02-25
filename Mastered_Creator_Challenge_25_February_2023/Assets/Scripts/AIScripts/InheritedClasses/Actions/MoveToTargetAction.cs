using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move To Target Action", menuName = "PluggableAI/Actions/Move To Target")]
public class MoveToTargetAction : Action
{
    public override void Act(AIThinker thinker)
    {
        MoveToTarget(thinker);
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
