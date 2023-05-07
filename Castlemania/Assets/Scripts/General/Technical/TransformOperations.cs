using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

class TransformOperations
{
    public static Transform GetClosest(Transform pivot, IEnumerable<Transform> targets)
    {
        if(targets.Count() == 0){
            throw new ArgumentException("Not Enough Transforms.");
        }
        float min = Mathf.Infinity;
        Transform retval = targets.First();
        foreach (var target in targets)
        {
            float curr = (target.position - pivot.position).sqrMagnitude;
            if (curr < min)
            {
                retval = target;
                min = curr;
            }
        }
        return retval;
    }
}
