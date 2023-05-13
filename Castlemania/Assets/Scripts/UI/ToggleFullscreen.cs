using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFullscreen : MonoBehaviour
{
    public void Invoke()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }      
}
