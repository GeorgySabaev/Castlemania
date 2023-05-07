using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_MeleeAttack : BaseAction
{
    public Collider2D trigger;
    public LayerMask layerMask;

    override public void Invoke()
    {
        var collisions = Physics2D.OverlapBoxAll(
            trigger.bounds.center,
            trigger.bounds.size / 2,
            0f,
            layerMask
        );
        Debug.Log(collisions.Length);
        foreach (var collision in collisions)
        {
            var handler = collision.GetComponent<A_DamageHandler>();
            if (handler)
            {
                handler.Invoke();
            }
        }
    }

    void OnDrawGizmos()
    {
        // Green
        Gizmos.color = new Color(1.0f, 0.0f, 0.0f);
        DrawRect(trigger.bounds);
    }

    void DrawRect(Bounds rect)
    {
        Gizmos.DrawWireCube(
            new Vector3(rect.center.x, rect.center.y, 0.01f),
            new Vector3(rect.size.x, rect.size.y, 0.01f)
        );
    }
}
