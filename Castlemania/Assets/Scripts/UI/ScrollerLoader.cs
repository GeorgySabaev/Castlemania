using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollerLoader : MonoBehaviour
{
    public Scrollbar slider;
    public string saveData;
    
    public void Start(){
        slider.value = PlayerPrefs.GetFloat(saveData, 0.5f);
    }
}