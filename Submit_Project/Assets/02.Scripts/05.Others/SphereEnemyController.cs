using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereEnemyController : EnemyController /***** Inheritance *****/
{
    private float speedAmplifier;
    void Start()
    {
        enemyPoints = 10;
        enemySpeed = 5.0f;
        speedAmplifier = Mathf.Abs(Mathf.Sin(Time.time));
        enemyRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement(); /***** Abstraction *****/
    }

    public override void Movement() /***** Polymorphism *****/
    {
        enemyRb.AddForce(Vector3.back * enemySpeed * speedAmplifier);
    }
}