using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class A_RotateToTarget : BaseAction
{
    public string target;
    public Transform pivot;

    override public void Invoke()
    {
        var targetList = ObjectTracker.containers[target].Select((x) => x.transform);
        if(targetList.Count() == 0){
            Debug.Log("No targets to aim at.");
            return;
        }
        transform.rotation = (
            Quaternion.Euler(
                0,
                0,
                Vector3.SignedAngle(
                    Vector3.up,
                    (
                        TransformOperations.GetClosest(pivot, targetList).position
                        + new Vector3(0.5f, 0.5f, 0)
                    ) - transform.position,
                    Vector3.forward
                )
            )
        );
    }
}
