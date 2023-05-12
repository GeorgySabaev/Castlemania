using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_SetPlayerPrefInt : BaseAction
{
    public string key;
    public int value;
    public override void Invoke()
    {
        PlayerPrefs.SetInt(key, value);
    }
}
