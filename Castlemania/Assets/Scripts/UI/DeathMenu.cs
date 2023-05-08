using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    public static DeathMenu instance;
    public static bool isActive;
    public void Awake()
    {
        if (instance)
        {
            Destroy(this);
        }
        instance = this;
        gameObject.SetActive(false);
    }
}
