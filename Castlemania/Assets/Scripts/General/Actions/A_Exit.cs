using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Exit : BaseAction
{
    public override void Invoke()
    {
        Application.Quit();
    }
}
