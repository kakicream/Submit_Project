using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnController : MonoBehaviour
{
    private bool enemyEntry;
    private MeshRenderer lockonRenderer;    
    private float lockOnTime = 1.5f;

    private void Awake()
    {
        enemyEntry = false;
        lockonRenderer = GetComponent<MeshRenderer>();
        lockonRenderer.forceRenderingOff = true;
    }

    private void Update()
    {
        RenderLockOn();
    }

    void RenderLockOn()
    {
        if (enemyEntry == true)
        {
            lockonRenderer.forceRenderingOff = false;
        }
        else
        {
            lockonRenderer.forceRenderingOff = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ENEMY"))
        {
            enemyEntry = true;
        }
        StartCoroutine(LockOnDuration());
    }

    IEnumerator LockOnDuration()
    {
        yield return new WaitForSeconds(lockOnTime);
        enemyEntry = false;
    }
}
