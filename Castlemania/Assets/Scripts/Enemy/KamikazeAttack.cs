using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeAttack : MonoBehaviour
{
    public LayerMask layerMask;
    public A_DamageHandler handler;

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(1);
        if (((1 << other.gameObject.layer) & layerMask) == 0)
        {
            return;
        }
        var other_handler = other.GetComponent<A_DamageHandler>();
        if (other_handler)
        {
            other_handler.Invoke();
            handler.Invoke();
        }
    }
}
