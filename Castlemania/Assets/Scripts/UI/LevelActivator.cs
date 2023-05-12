using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelActivator : MonoBehaviour
{
    public Button button;
    public int level;
    void Awake()
    {
        if(PlayerPrefs.GetInt("Level", 1) < level){
            button.interactable = false;
        }
    }
}
