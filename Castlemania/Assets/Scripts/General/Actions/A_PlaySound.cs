using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_PlaySound : BaseAction
{
    new public AudioSource audio;

    override public void Invoke()
    {
        audio.Play();
    }
}
