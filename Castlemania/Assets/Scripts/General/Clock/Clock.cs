using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clock : MonoBehaviour
{
    public AudioSource track;
    public float bpm;

    public float offset;

    public float preHitWindowPart;
    public float postHitWindowPart;
    public float gracePeriodPart;

    public UnityEvent BeatStarts;
    public UnityEvent BeatFires;
    public UnityEvent BeatResolves;
    public UnityEvent PostBeatResolves;

    [Space(10)]
    public bool canHit;
    public bool canFail;
    public bool active;

    public static Clock instance;

    public double targetTime;

    public double rate;

    public double preHitWindow;
    public double postHitWindow;
    public double gracePeriod;
    public double pauseTime;
    public int state = 2;

    void Awake()
    {
        instance = this;
    }

    public void Activate()
    {
        rate = 60.0 / bpm;
        preHitWindow = rate * preHitWindowPart;
        postHitWindow = rate * postHitWindowPart;
        gracePeriod = rate * gracePeriodPart;
        targetTime = AudioSettings.dspTime + rate * offset;
        active = true;
        track.Play();
    }

    public void Pause()
    {
        pauseTime = AudioSettings.dspTime;
        active = false;
        track.Pause();
    }

    public void Resume()
    {
        targetTime += AudioSettings.dspTime - pauseTime;
        active = true;
        track.UnPause();
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        if (!active)
        {
            return;
        }
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
                    Invoker.Invoke(BeatStarts);
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
