using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float enemySpeed;
    private float destroyZPos = -10.0f;

    void Update()
    {
        transform.position += Vector3.back * Time.deltaTime * enemySpeed;

        if (transform.position.z <= destroyZPos)
        {
            GameManager.isGameOver_GM = true;
            Destroy(gameObject);
        }
    }
}
