using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected float enemySpeed;
    private float destroyZPos = -7.0f;

    [SerializeField] protected static int enemyPoints;
    [SerializeField] protected float speedAmplifier;

    protected Rigidbody enemyRb;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody>();        
    }

    public static int enemyPointToBullet
    {
        get { return enemyPoints; }
        set { enemyPoints = value; }
    }

    public virtual void Movement()
    {
        enemyRb.AddForce(Vector3.back * enemySpeed * speedAmplifier);
        destroyEnemy();
    }

    void destroyEnemy()
    {
        if (transform.position.z <= destroyZPos)
        {
            GameManager.isGameOver_GM = true;
            Destroy(gameObject);
        }
    }
}
