using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move To Base Action", menuName = "PluggableAI/Actions/Move To Base")]
public class MoveToBaseAction : Action
{
    public override void Act(AIThinker thinker)
    {
        MoveToBase(thinker);
    }

    void MoveToBase(AIThinker thinker)
    {
        Vector3 direction = GetBaseDirection(thinker);

        thinker._rb.velocity = new Vector3(direction.x * thinker.chaseSpeed, thinker._rb.velocity.y, direction.z * thinker.chaseSpeed);
        thinker.transform.rotation = Quaternion.Euler(0, GetRotation(thinker), 0);
    }

    Vector3 GetBaseDirection(AIThinker thinker)
    {
        Vector3 basePosition = GameObject.FindGameObjectWithTag("Base").transform.position;
        Vector3 direction = basePosition - thinker.transform.position;

        direction = direction.normalized;

        return direction;
    }

    float GetRotation(AIThinker thinker)
    {
        Vector3 lookDirection = Vector3.zero;
        lookDirection = GameObject.FindGameObjectWithTag("Base").transform.position - thinker.transform.position;



        float targetAngle = Mathf.Atan2(lookDirection.x, lookDirection.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(thinker.transform.eulerAngles.y, targetAngle, ref thinker.currSmoothVelocity, thinker.rotationSmooth);

        return angle;
    }
}
