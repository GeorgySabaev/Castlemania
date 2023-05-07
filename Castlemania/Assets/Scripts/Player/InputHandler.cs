using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public InputType inputType;
    public string eventName;
    public MoveType moveType;
    public UnityEvent<MoveType> invokes;

    public void Start()
    {
        switch (inputType)
        {
            case InputType.started:
                InputManager.instance.input.actions[eventName].started += HandleInput;
                break;
            case InputType.canceled:
                InputManager.instance.input.actions[eventName].canceled += HandleInput;
                break;
        }
    }

    public void HandleInput(InputAction.CallbackContext context)
    {
        if (Clock.instance.canHit)
        {
            invokes.Invoke(moveType);
        }else{
            invokes.Invoke(MoveType.fail);
        }
    }
}
