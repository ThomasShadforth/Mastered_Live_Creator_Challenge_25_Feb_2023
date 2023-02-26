using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move To Player Action", menuName = "PluggableAI/Actions/Move To Player")]
public class MoveToPlayerAction : Action
{
    public override void Act(AIThinker thinker)
    {
        

        MoveToPlayer(thinker);
    }

    void MoveToPlayer(AIThinker thinker)
    {
        Vector3 direction = GetMoveDirection(thinker);

        thinker._rb.velocity = new Vector3(direction.x * thinker.chaseSpeed, thinker._rb.velocity.y, direction.z * thinker.chaseSpeed);

        thinker.transform.rotation = Quaternion.Euler(0, GetRotationTowardPlayer(thinker), 0);
    }

    float GetRotationTowardPlayer(AIThinker thinker)
    {
        Vector3 lookDirection = Vector3.zero;
        lookDirection = thinker.playerTarget.position - thinker.transform.position;

        float targetAngle = Mathf.Atan2(lookDirection.x, lookDirection.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(thinker.transform.eulerAngles.y, targetAngle, ref thinker.currSmoothVelocity, thinker.rotationSmooth);

        return angle;
    }

    Vector3 GetMoveDirection(AIThinker thinker)
    {
        Vector3 direction = Vector3.zero;
        direction = thinker.playerTarget.position - thinker.transform.position;
        direction = direction.normalized;

        return direction;
    }
}
