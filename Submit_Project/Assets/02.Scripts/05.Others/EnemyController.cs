using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected static int enemyPoints;

    [SerializeField] protected float enemySpeed;
    [SerializeField] protected float speedAmplifier;

    protected Rigidbody enemyRb;

    public ParticleSystem explosionParticle;

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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GAMEOVER"))
        {
            GameManager.isGameOver_GM = true;
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    }
}
