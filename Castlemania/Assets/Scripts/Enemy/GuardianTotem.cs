using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GuardianTotem : MonoBehaviour
{
    public A_DamageHandler handler;
    public LineRenderer line;

    void Start(){
        handler.invulnerable = true;
    }
    void LateUpdate(){
        line.SetPositions(new Vector3[]{Vector3.zero, handler.transform.position - transform.position});
    }
    void OnDestroy(){
        handler.invulnerable = false;
    }
}
