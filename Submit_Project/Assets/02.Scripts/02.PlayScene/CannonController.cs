using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    #region BulletSpawn
    public GameObject[] cannonParts;
    public GameObject bullet;
    private Vector3 bulletSpawnPos = new Vector3(0.0f, 0.0f, 1.0f);
    #endregion

    #region BulletFire
    private static int fireCount = 5;
    public static int canYouFire
    {
        /***** Encapsulation *****/
        get { return fireCount; }
        set { fireCount = value; }
    }
    public AudioClip shootSound;
    public AudioClip[] reloadSound;
    private new AudioSource audio;
    [SerializeField] private float shootVolume;
    [SerializeField] private float reloadVolume;
    #endregion

    private void Start()
    {
        PlaySceneUI.UpdateLoad();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        /***** Abstraction *****/
        GameOverChecker(); // Method 1
        ReloadChecker(); // Method 2
    }

    #region Method 1
    void GameOverChecker()
    {
        if (GameManager.isGameOver_GM == false)
        {
            /***** Abstraction *****/
            ProduceBullet(); // Method 1-1
        }
        if (GameManager.isGameOver_GM == true)
        {
            Destroy(gameObject);
        }
    }

    // Method 1-1
    void ProduceBullet()
    {
        for (int index = 0; index < cannonParts.Length; index++)
        {
            if (Input.GetKeyDown((index + 1).ToString()) && fireCount > 0)
            {
                /***** Abstraction *****/
                InstantiateBullet(index); // Method 1-2
                fireCount--;
                PlaySceneUI.UpdateLoad();
            }
        }
    }

    // Method 1-2
    void InstantiateBullet(int cannonIndex)
    {
        Instantiate(bullet, cannonParts[cannonIndex].transform.position + bulletSpawnPos, bullet.transform.rotation);
        audio.PlayOneShot(shootSound, shootVolume);
    }
    #endregion

    #region Method 2
    void ReloadChecker()
    {
        if (BulletController.isReloaded == true)
        {
            int soundIndex = Random.Range(0, reloadSound.Length);
            audio.PlayOneShot(reloadSound[soundIndex], reloadVolume);
            BulletController.isReloaded = false;
        }
    }
    #endregion
}