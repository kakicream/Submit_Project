using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    #region Bullet Physics
    private Rigidbody bulletRb;
    #endregion

    #region Reload Bool
    private static bool reloadCheck;
    public static bool isReloaded
    {
        /***** Encapsulation *****/
        get { return reloadCheck; }
        set { reloadCheck = value; }
    }
    #endregion

    #region Bullet Start
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        bulletRb.mass = 3.0f;
    }
    #endregion

    #region Bullet Update
    void Update()
    {
        bulletRb.AddForce(Vector3.forward, ForceMode.Impulse);
    }
    #endregion

    #region Bullet Trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ENEMY"))
        {
            PlaySceneUI.AddPoint(EnemyController.enemyPointToBullet);
            Destroy(other.gameObject);
            ReLoadBullets();
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("DESTROYER"))
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region BulletReload
    private void OnDestroy()
    {
        reloadCheck = true;
        ReLoadBullets(); /***** Abstraction *****/
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