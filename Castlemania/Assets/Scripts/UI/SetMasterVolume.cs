using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMasterVolume : MonoBehaviour
{
    public void Invoke()
    {
        MasterVolumeController.SetVolume();
    }
}
