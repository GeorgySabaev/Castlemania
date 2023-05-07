using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_BeamAttack : BaseAction
{
    public LayerMask layerMask;

    override public void Invoke()
    {
        var hits = Physics2D.RaycastAll(
            transform.position,
            transform.up,
            distance: Mathf.Infinity,
            layerMask: layerMask
        );
        foreach (var hit in hits)
        {
            var handler = hit.collider.GetComponent<A_DamageHandler>();
            if (handler) {
                handler.Invoke();
            }
        }
    }
}
