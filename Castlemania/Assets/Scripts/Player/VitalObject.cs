using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitalObject : MonoBehaviour
{
    void OnDestroy()
    {
        if (DeathMenu.instance)
        {
            DeathMenu.instance.gameObject.SetActive(true);
        }
        DeathMenu.isActive = true;
        if (Clock.instance)
        {
            Clock.instance.Pause();
        }
        Menu.LeaveMenu();
    }
}
