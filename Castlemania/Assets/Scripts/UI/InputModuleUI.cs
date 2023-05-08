using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;

public class InputModuleUI : MonoBehaviour
{
    public static InputModuleUI instance;
    public InputSystemUIInputModule inputModule;

    void Awake()
    {
        if (instance)
        {
            Destroy(this);
        }
        instance = this;
    }
}
