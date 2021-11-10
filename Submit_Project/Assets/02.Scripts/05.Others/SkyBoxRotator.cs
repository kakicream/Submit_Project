using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxRotator : MonoBehaviour
{
    [SerializeField] private float rotationAngle;

    private void Start()
    {
        rotationAngle = Random.Range(1, 10);
    }

    void Update()
    {
        transform.Rotate(Vector3.up, rotationAngle * Time.deltaTime);
    }
}
