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
            // Execute Points Addition method from the PlaySceneUI
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
