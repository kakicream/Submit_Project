using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerController : MonoBehaviour
{
    public ParticleSystem gameOverParticle;
    private int particlePlayCount = 1;
    private Vector3 particlePos = new Vector3(15, 5, -10);

    void Update()
    {
        ParticleOn(); /***** Abstraction *****/
    }

    void ParticleOn()
    {
        if (GameManager.isGameOver_GM == true && particlePlayCount > 0)
        {
            Instantiate(gameOverParticle, particlePos, gameOverParticle.transform.rotation);
            particlePlayCount--;
        }
    }
}