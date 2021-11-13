using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Enemy Variables
    [SerializeField] protected static int enemyPoints;
    [SerializeField] protected float enemySpeed;
    //[SerializeField] protected float speedAmplifier;
    #endregion

    #region Enemy Physics
    protected Rigidbody enemyRb;
    #endregion

    #region Enemy Score
    public static int enemyPointToBullet
    {
        /***** Encapsulation *****/
        get { return enemyPoints; }
        set { enemyPoints = value; }
    }
    #endregion

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    #region Enemy Movement
    public virtual void Movement()
    {
        enemyRb.AddForce(Vector3.back * enemySpeed);
    }
    #endregion

    #region Explosion
    public ParticleSystem explosionParticle;

    private void OnDestroy()
    {
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GAMEOVER"))
        {
            GameManager.isGameOver_GM = true;
            Destroy(gameObject);
        }
    }
}