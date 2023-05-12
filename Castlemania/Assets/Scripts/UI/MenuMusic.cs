using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public static MenuMusic instance;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        var objects = FindObjectsOfType<MenuMusic>();
        if(objects.Length > 1){
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void OnSceneLoad(){
        var objects = FindObjectsOfType<MenuMusicMarker>();
        if(objects.Length == 0){
            Destroy(this.gameObject);
            return;
        }
    }
}
