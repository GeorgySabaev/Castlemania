using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clock : MonoBehaviour
{
    public float bpm;

    public float offset;

    public float preHitWindowPart;
    public float postHitWindowPart;

    public UnityEvent BeatFires;
    public UnityEvent BeatResolves;
    public UnityEvent PostBeatResolves;

    [Space(10)]
    public bool canHit;

    public static Clock instance;

    public double targetTime;

    public int beatNumber;

    public double rate;

    public double preHitWindow;
    public double postHitWindow;

    public int state = 2;

    // beat - state 0 - end of window - state 1 - start of window - state 2 - beat
    void Awake()
    {
        instance = this;
        rate = 60.0 / bpm;
        beatNumber = 0;
        preHitWindow = rate * preHitWindowPart;
        postHitWindow = rate * postHitWindowPart;
        targetTime = AudioSettings.dspTime+rate*offset;
    }
    void OnAudioFilterRead(float[] data, int channels)
    {
        if (AudioSettings.dspTime >= targetTime)
        {
            switch (state)
            {
                case 0:
                    Invoker.Invoke(BeatResolves);
                    Invoker.Invoke(PostBeatResolves);
                    canHit = false;
                    targetTime += rate - preHitWindow - postHitWindow;
                    state = 1;
                    return;
                case 1:
                    canHit = true;
                    targetTime += preHitWindow;
                    state = 2;
                    return;
                case 2:
                    Invoker.Invoke(BeatFires);
                    targetTime += postHitWindow;
                    state = 0;
                    return;
            }
        }
    }
}
