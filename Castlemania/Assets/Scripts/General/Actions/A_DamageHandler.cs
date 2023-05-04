using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_DamageHandler : MonoBehaviour, IAction
{
    public void Invoke()
    {
        Destroy(gameObject);
    }
}
