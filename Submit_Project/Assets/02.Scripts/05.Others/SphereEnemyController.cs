using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***** Inheritance *****/
public class SphereEnemyController : EnemyController
{
    void Start()
    {
        enemyPoints = 10;
        enemySpeed = 10.0f;
        speedAmplifier = Mathf.Abs(Mathf.Sin(Time.time));
        enemyRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
    }

    /***** Polymorphism *****/
    public override void Movement()
    {
        base.Movement();
    }
}
