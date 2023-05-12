using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    void Start()
    {
        InputManager.instance.input.actions["Pause"].started += TogglePauseHandler;
    }
    public void TogglePauseHandler(InputAction.CallbackContext context){
        TogglePause();
    }
    public void TogglePause(){
        if(DeathMenu.isActive){
            return;
        }
        Debug.Log(Time.time);
        if(Menu.inMenu){
            Menu.LeaveMenu();
            Clock.instance.Resume();
        } else{
            Menu.LoadMenu("Pause");
            Clock.instance.Pause();
        }
    }
}
