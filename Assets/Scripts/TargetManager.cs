using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Size
{
    SMALL, MEDIUM, LARGE
}
public class TargetManager : Singleton<TargetManager>
{
    float moveDistance = 500f;
    public float speed;
    Transform startPos;
    Transform endPos;
    public Transform moveToPos;
    public Transform[] spawnPoints;
    public List<GameObject> enemies;
    public GameObject[] enemyTypes;

    void Start()
    {
       
        StartCoroutine(moveRandom());
        SetUpAI();
        SpawnEnemy();
        StartCoroutine(EnemyDelaySpawn());
        StartCoroutine(EnemyDelaySpawn());
    }

    void SetUpAI()
    {
        startPos = transform;
        endPos = _EM.GetRandomSpawnPoint();
        moveToPos = endPos;
    }

    IEnumerator moveRandom()
    {
        Vector3 direction = new Vector3();
        int rnd = Random.Range(0, 5);

        if (rnd == 0)
            direction = Vector3.back;
        if (rnd == 1)
            direction = Vector3.forward;
        if (rnd == 2)
            direction = Vector3.down;
        if (rnd == 3)
            direction = Vector3.right;
        if (rnd == 4)
            direction = Vector3.up;
        if (rnd == 5)
            direction = Vector3.left;

        for (int i = 0; i < moveDistance; i++)
        {
            transform.Translate(direction * speed);
            yield return null;
        }
        yield return new WaitForSeconds(3);

        StartCoroutine(moveRandom());
    }
    void OnEnemyDied(Target _enemy)
    {
        EnemyDestroy(_enemy.gameObject);
    }
    void SpawnEnemy()
    {
        int sp = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int rnd = Random.Range(0, enemyTypes.Length);
            GameObject go = Instantiate(enemyTypes[rnd], spawnPoints[sp].position, spawnPoints[sp].rotation);
            enemies.Add(go);
        }

    }

    void EnemyDestroy(GameObject _enemy)
    {
        if (enemies.Count == 0)
            return;
        Destroy(_enemy);
        enemies.Remove(_enemy);
        GameEvents.ReportListChange(enemies.Count);

    }

    public Transform GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }
    private void OnEnable()
    {
        GameEvents.OnEnemyDied += OnEnemyDied;
        GameEvents.OnGameStateChange += OnGameStateChange;
        
    }
    private void OnDisable()
    {
        GameEvents.OnEnemyDied -= OnEnemyDied;
        GameEvents.OnGameStateChange -= OnGameStateChange;
    }
    IEnumerator EnemyDelaySpawn()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int rnd = Random.Range(0, enemyTypes.Length);
            GameObject go = Instantiate(enemyTypes[rnd], spawnPoints[i].position, spawnPoints[i].rotation);
            enemies.Add(go);
            yield return new WaitForSeconds(2);
        }
    }
    void OnGameStateChange(GameState _gameState)
    {
        switch (_gameState)
        {
            case GameState.Playing:
                StartCoroutine(EnemyDelaySpawn());
                break;
            case GameState.Paused:
            case GameState.GameOver:
                StopCoroutine(EnemyDelaySpawn());
                break;

        }
    }
}
