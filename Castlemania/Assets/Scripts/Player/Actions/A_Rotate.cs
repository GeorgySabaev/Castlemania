using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Rotate : BaseAction
{
    override public void Invoke(){
        this.transform.Rotate(new Vector3(0, 0, 45));
    }
}
