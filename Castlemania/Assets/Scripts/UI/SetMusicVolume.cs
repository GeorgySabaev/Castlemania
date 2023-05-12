using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMusicVolume : MonoBehaviour
{
    // Start is called before the first frame update
    public void Invoke()
    {
        MenuMusic.instance.gameObject.GetComponent<MusicVolumeController>()?.SetVolume();
    }
}
