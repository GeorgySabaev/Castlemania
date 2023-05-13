using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatStrictnessSetup : MonoBehaviour
{
    void Start()
    {
        float strictness = PlayerPrefs.GetFloat("Strictness", 0f);
        Clock.instance.postHitWindowPart *= (1.5f - strictness);
        Clock.instance.preHitWindowPart *= (1.5f - strictness);
        Clock.instance.gracePeriodPart *= (1.5f - strictness);
    }
}
