using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_PlaySound : MonoBehaviour, IAction
{
    new public AudioSource audio;

    public void Invoke()
    {
        audio.Play();
    }
}
