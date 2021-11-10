using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody bulletRb;
    
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        bulletRb.mass = 3.0f;
    }

    void Update()
    {
        bulletRb.AddForce(Vector3.forward, ForceMode.Impulse);
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
        else if (other.gameObject.CompareTag("DESTROYER"))
        {
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
