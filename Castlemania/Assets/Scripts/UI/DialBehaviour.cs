using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialBehaviour : MonoBehaviour
{
    public SpriteRenderer lightTexture;
    public Transform arrow;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Clock.instance.BeatFires.AddListener(Rotate);
        Clock.instance.BeatResolves.AddListener(MakeRed);
        Clock.instance.BeatStarts.AddListener(MakeGreen);
    }

    // Update is called once per frame
    void MakeRed()
    {
        lightTexture.color = Color.red;
    }
    void MakeGreen()
    {
        lightTexture.color = Color.green;
    }
    void Rotate()
    {
        audioSource.Play();
        arrow.Rotate(new Vector3(0, 0, 45));
    }
}
