using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : Singleton<Enemy_Manager>
{
    public string[] enemyNames;
    public Transform[] spawnPoints;
    public GameObject[] enemyTypes;

    public List<GameObject> enemies;
   
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            KillAllEnemies();
        //EnemyDestroy(enemies[0]);

        if (Input.GetKeyDown(KeyCode.B))
            KillSpecific("_B");
        if(Input.GetKeyDown(KeyCode.I))
            SpawnEnemy();
    }













    /// <summary>
    /// kills a specific enemy
    /// </summary>
    /// <param name="_condition"></param>
    void KillSpecific(string _condition) // broken wont destroy all of them at once
    {
        int eCount = enemies.Count;
        for (int i = 0; i< eCount; i++)
        {
            if (enemies[i].name.Contains(_condition) )
            {
                EnemyDestroy(enemies[i]);
            }
        }
    }

    /// <summary>
    /// Spawns random enemy Types in scene at a spawnPoint
    /// </summary>
    void SpawnEnemy()
    {
        int sp = Random.Range(0, spawnPoints.Length);
        
        //for (int i = 0; i < spawnPoints.Length; i++)
        //{
            int rnd = Random.Range(0, enemyTypes.Length);
            GameObject go = Instantiate(enemyTypes[rnd], spawnPoints[sp].position, spawnPoints[sp].rotation);
            enemies.Add(go);
       // }

    }

/// <summary>
/// Destroys an enemy based on the GameObject Passed Through
/// </summary>
/// <param name="_enemy"></param>
    void EnemyDestroy(GameObject _enemy)
    {
        if (enemies.Count == 0)
            return;
        Destroy(_enemy);
        enemies.Remove(_enemy);
    }


    /// <summary>
    /// Kills all enemies in scene
    /// </summary>
    void KillAllEnemies()
    {
        int eCount = enemies.Count;
        for (int i =0; i< eCount; i++)
        {
            EnemyDestroy(enemies[0]);
        }
    }

}