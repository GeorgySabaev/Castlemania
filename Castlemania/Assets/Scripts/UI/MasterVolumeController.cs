using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterVolumeController : MonoBehaviour
{
    void Start() {
        SetVolume();
    }

    public static void SetVolume()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("MasterVolume", 0.5f);
    }
}
