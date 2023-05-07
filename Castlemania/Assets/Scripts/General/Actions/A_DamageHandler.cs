using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_DamageHandler : MonoBehaviour, IAction
{
    public bool invulnerable;

    public void Invoke()
    {
        if (!invulnerable)
        {
            Destroy(gameObject);
        }
    }
}
