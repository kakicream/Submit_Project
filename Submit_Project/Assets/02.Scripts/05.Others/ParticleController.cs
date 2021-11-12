using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] private float playTime;
    void Start()
    {
        StartCoroutine(DurationTime());
    }

    IEnumerator DurationTime()
    {
        yield return new WaitForSeconds(playTime);
        Destroy(gameObject);
    }
}
