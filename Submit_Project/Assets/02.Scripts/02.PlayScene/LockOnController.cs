using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnController : MonoBehaviour
{
    #region LockOn preferences
    private bool enemyEntry;
    private MeshRenderer lockonRenderer;
    private float lockOnTime = 1.5f;
    #endregion

    #region LockOnAwake
    private void Awake()
    {
        LockOnAwake(); /***** Abstraction *****/
    }

    void LockOnAwake()
    {
        enemyEntry = false;
        lockonRenderer = GetComponent<MeshRenderer>();
        lockonRenderer.forceRenderingOff = true;
    }
    #endregion

    #region LockOnUpdate
    private void Update()
    {
        LockOnUpdate(); /***** Abstraction *****/
    }

    void LockOnUpdate()
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
    #endregion

    #region LockOnTrigger
    private void OnTriggerEnter(Collider other)
    {
        /***** Abstraction *****/
        LockOnTrigger(other); // Method 1
    }

    // Method 1
    void LockOnTrigger(Collider other)
    {
        if (other.CompareTag("ENEMY"))
        {
            enemyEntry = true;
        }
        StartCoroutine(LockOnDuration()); // IEnumerator1
    }

    // IEnumerator 1
    IEnumerator LockOnDuration()
    {
        yield return new WaitForSeconds(lockOnTime);
        enemyEntry = false;
    }
    #endregion
}