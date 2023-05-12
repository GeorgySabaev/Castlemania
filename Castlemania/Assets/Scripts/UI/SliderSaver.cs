using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSaver : MonoBehaviour
{
    public Slider slider;
    public string saveData;
    
    public void Save(){
        PlayerPrefs.SetFloat(saveData, slider.value);
        PlayerPrefs.Save();
    }
}
