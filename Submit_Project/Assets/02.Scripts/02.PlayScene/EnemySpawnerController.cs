using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    #region EnemySpawnPos
    [SerializeField] private int xRange = 3;
    [SerializeField] private int yRange = 3;
    [SerializeField] private float spawnRate = 3.0f;
    #endregion

    #region EnemyPrefabs
    public GameObject[] enemy;
    #endregion

    #region EnemySpawn Start
    void Start()
    {
        InvokeRepeating("EnemySpawn", 1.0f, spawnRate);
    }

    void EnemySpawn()
    {
        int randomindex = Random.Range(0, enemy.Length);
        float randomXPos = Random.Range(-1, 2);
        float randomYPos = Random.Range(-1, 2);
        float zPos = 100.0f;

        Vector3 randomSpawnPos = new Vector3(randomXPos * xRange, randomYPos * yRange, zPos);

        Instantiate(enemy[randomindex], randomSpawnPos, enemy[randomindex].transform.rotation);
    }
    #endregion

    #region EnemySpawn Update
    void Update()
    {
        EnemySpawnerCancel(); /***** Abstraction *****/
    }

    void EnemySpawnerCancel()
    {
        if (GameManager.isGameOver_GM == true)
        {
            CancelInvoke();
        }
    }
    #endregion
}