using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputHandlerRaw : MonoBehaviour
{
    public InputType inputType;
    public string eventName;
    public UnityEvent invokes;

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
        invokes.Invoke();
    }
}
