using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_DamageHandler : BaseAction
{
    public bool invulnerable;

    override public void Invoke()
    {
        if (!invulnerable)
        {
            Destroy(gameObject);
        }
    }
}
