using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.sceneLoaded += OnSceneLoad;
    }
    void OnSceneLoad(Scene scene, LoadSceneMode loadSceneMode){
        var objects = FindObjectsOfType<MenuMusicMarker>();
        if(objects.Length == 0 && this){
            Destroy(this.gameObject);
            return;
        }
    }
}
