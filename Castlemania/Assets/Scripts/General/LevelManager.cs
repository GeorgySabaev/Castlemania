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
        //StartCoroutine(LoadingScene());
    }

    public void Load(){
        //canLoad = true;
        SceneManager.LoadScene(sceneName);
    }
    // old code for scene loading, more performant but cannot preload multiple scenes at once
    /*IEnumerator LoadingScene()
    {
        yield return null;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            yield return null;
            if(canLoad){
                asyncOperation.allowSceneActivation = true;
            }
        }
    }*/
}
