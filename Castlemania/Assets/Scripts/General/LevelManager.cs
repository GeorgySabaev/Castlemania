using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string sceneName;
    public bool canLoad;

    public void Awake()
    {
        StartCoroutine(LoadingScene());
    }

    public void Load(){
        canLoad = true;
    }

    IEnumerator LoadingScene()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            yield return null;
            if(canLoad){
                asyncOperation.allowSceneActivation = true;
            }
        }
    }
}
