using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public PlayerInput input;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance){
            Destroy(this);
        }
        instance = this;
    }

    // Update is called once per frame
}
