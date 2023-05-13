using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatStrictnessSave : MonoBehaviour
{
    public Scrollbar scrollbar;
    public void Invoke(){
        PlayerPrefs.SetFloat("Strictness", scrollbar.value);
        PlayerPrefs.Save();
    }
}
