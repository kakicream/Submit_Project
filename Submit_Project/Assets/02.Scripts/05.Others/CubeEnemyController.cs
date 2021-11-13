using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnemyController : EnemyController /***** Inheritance *****/
{
    private float speedAmplifier;
    void Start()
    {
        enemyPoints = 20;
        enemySpeed = 10.0f;
        speedAmplifier = Mathf.Abs(Mathf.Log(Time.time));
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