using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderEnemyController : EnemyController /***** Inheritance *****/
{
    private float speedAmplifier;
    void Start()
    {
        enemyPoints = 15;
        enemySpeed = 7.0f;
        speedAmplifier = Mathf.Abs(Mathf.Cos(Time.time));
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