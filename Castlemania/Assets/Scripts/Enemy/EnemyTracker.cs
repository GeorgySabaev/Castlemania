using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTracker : MonoBehaviour
{
    private static HashSet<EnemyTracker> enemies = new HashSet<EnemyTracker>();
    void Start()
    {
        enemies.Add(this);
    }
    void OnDestroy()
    {
        enemies.Remove(this);
        if (enemies.Count == 0 && SceneManager.GetActiveScene().isLoaded){
            WinCondition.instance.OnWin.Invoke();
        }
    }
}
