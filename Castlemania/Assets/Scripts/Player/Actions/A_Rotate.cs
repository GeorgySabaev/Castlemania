using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Rotate : MonoBehaviour, IAction
{
    public void Invoke(){
        this.transform.Rotate(new Vector3(0, 0, 45));
    }
}
