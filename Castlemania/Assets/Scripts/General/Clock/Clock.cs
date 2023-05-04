using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clock : MonoBehaviour
{
    public float bpm;

    public float offset;

    public float hitWindowPart;

    public UnityEvent BeatFires;

    [Space(10)]
    public bool canHit;

    public static Clock instance;

    public double targetTime;

    public int beatNumber;

    public double rate;

    public double hitWindow;

    public int state = 2;

    // beat - state 0 - end of window - state 1 - start of window - state 2 - beat
    void Awake()
    {
        instance = this;
        rate = 60.0 / bpm;
        beatNumber = 0;
        hitWindow = rate * hitWindowPart;
        targetTime = AudioSettings.dspTime+rate*offset;
    }
    void OnAudioFilterRead(float[] data, int channels)
    {
        if (AudioSettings.dspTime >= targetTime)
        {
            switch (state)
            {
                case 0:
                    canHit = false;
                    targetTime += rate - 2 * hitWindow;
                    state = 1;
                    return;
                case 1:
                    canHit = true;
                    targetTime += hitWindow;
                    state = 2;
                    return;
                case 2:
                    Invoker.Invoke(BeatFires);
                    targetTime += hitWindow;
                    state = 0;
                    return;
            }
        }
    }
}
