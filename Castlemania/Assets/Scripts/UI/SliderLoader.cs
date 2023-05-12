using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderLoader : MonoBehaviour
{
    public Slider slider;
    public string saveData;
    
    public void Start(){
        slider.value = PlayerPrefs.GetFloat(saveData, 0.5f);
    }
}