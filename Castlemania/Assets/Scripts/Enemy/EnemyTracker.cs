using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (enemies.Count == 0){
            WinCondition.instance.OnWin.Invoke();
        }
    }
}
