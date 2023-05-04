using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TriggerList2D : MonoBehaviour
{    
    public List<Transform> colliding;
    public void OnTriggerEnter2D(Collider2D other){
        var root = other.transform;
        if(!colliding.Contains(root)){
            colliding.Add(root);
        }
    }
    public void OnTriggerExit2D(Collider2D other){
        var root = other.transform;
        if(colliding.Contains(root)){
            colliding.Remove(root);
        }
    }
}
