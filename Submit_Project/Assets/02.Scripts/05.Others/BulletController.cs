using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody bulletRb;
    [SerializeField] private float bulletSpeed;

    private float destroyZPos = 150.0f;

    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        bulletRb.mass = 3.0f;
    }

    void Update()
    {
        bulletRb.AddForce(Vector3.forward, ForceMode.Impulse);
        if (transform.position.z > destroyZPos)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ENEMY"))
        {
            PlaySceneUI.AddPoint(EnemyController.enemyPointToBullet);
            Destroy(other.gameObject);
            /***** Abstraction *****/
            ReLoadBullets();
            Destroy(gameObject);
        }
    }

    #region Abstraction
    private void OnDestroy()
    {
        ReLoadBullets();
    }

    void ReLoadBullets()
    {
        if (CannonController.canYouFire < 5)
        {
            CannonController.canYouFire++;
        }
        PlaySceneUI.UpdateLoad();
    }
    #endregion
}
