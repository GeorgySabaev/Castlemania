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
    public float gracePeriodPart;

    public UnityEvent BeatFires;
    public UnityEvent BeatResolves;
    public UnityEvent PostBeatResolves;

    [Space(10)]
    public bool canHit;
    public bool canFail = true;

    public static Clock instance;

    public double targetTime;

    public int beatNumber;

    public double rate;

    public double preHitWindow;
    public double postHitWindow;
    public double gracePeriod;

    public int state = 2;

    // beat - state 0 - end of window - state 1 - start of window - state 2 - beat
    void Awake()
    {
        instance = this;
        rate = 60.0 / bpm;
        beatNumber = 0;
        preHitWindow = rate * preHitWindowPart;
        postHitWindow = rate * postHitWindowPart;
        gracePeriod = rate * gracePeriodPart;
        targetTime = AudioSettings.dspTime+rate*offset;
    }
    void OnAudioFilterRead(float[] data, int channels)
    {
        if (AudioSettings.dspTime >= targetTime)
        {
            switch (state)
            {
                case 0: // hit window end, move resolution, grace period start
                    Invoker.Invoke(BeatResolves);
                    Invoker.Invoke(PostBeatResolves);
                    canHit = false;
                    canFail = false;
                    targetTime += rate - preHitWindow - postHitWindow - gracePeriod;
                    state = 1;
                    return;
                case 1: // grace period end
                    canFail = true;
                    targetTime += gracePeriod;
                    state = 2;
                    return;
                case 2: // hit window start
                    canHit = true;
                    targetTime += preHitWindow;
                    state = 3;
                    return;
                case 3: // exact beat
                    Invoker.Invoke(BeatFires);
                    targetTime += postHitWindow;
                    state = 0;
                    return;
                
            }
        }
    }
}
