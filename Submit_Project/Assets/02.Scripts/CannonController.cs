using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject[] canonParts;
    public GameObject bullet;

    private Vector3 bulletSpawnPos = new Vector3(0.0f, 0.0f, 1.0f);

    void Update()
    {
        if (GameManager.isGameOver_GM == false)
        {
            ProduceBullet();
        }
    }

    void ProduceBullet()
    {
        // Think of better ways to shorten it, there must be better ways!
        // 1. get input
        // 2. (if it's numpad input), convert that value to integer
        // 3. Run InstantiateBullet(inputNum)

        for (int index = 0; index < canonParts.Length; index++)
        {
            if (Input.GetKeyDown((index+1).ToString()))
            {
                InstantiateBullet(index);
            }
        }
    }

    void InstantiateBullet(int canonIndex)
    {
        Instantiate(bullet, canonParts[canonIndex].transform.position + bulletSpawnPos, bullet.transform.rotation);
    }
}
