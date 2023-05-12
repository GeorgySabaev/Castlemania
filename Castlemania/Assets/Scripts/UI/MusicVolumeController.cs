using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolumeController : MonoBehaviour
{
    public AudioSource audioSource;

    void Start() {
        SetVolume();
    }

    public void SetVolume()
    {
        audioSource.volume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
    }
}
