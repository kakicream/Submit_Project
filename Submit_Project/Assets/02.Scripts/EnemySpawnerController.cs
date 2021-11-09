using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    [SerializeField] private int xRange = 3;
    [SerializeField] private int yRange = 3;

    public GameObject[] enemy;

    void Start()
    {
        InvokeRepeating("EnemySpawn", 1.0f, 5.0f);
    }

    void Update()
    {
        if (GameManager.isGameOver_GM == true)
        {
            CancelInvoke();
        }
    }

    void EnemySpawn()
    {
        int randomindex = Random.Range(0, enemy.Length);
        float randomXPos = Random.Range(-1,2);
        float randomYPos = Random.Range(-1,2);
        float zPos = 100.0f;

        Vector3 randomSpawnPos = new Vector3(randomXPos*xRange, randomYPos*yRange, zPos);

        Instantiate(enemy[randomindex], randomSpawnPos, enemy[randomindex].transform.rotation);
    }
    IEnumerator SpawnRate()
    {
        yield return new WaitForSeconds(5.0f);
    }
}
