using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***** Inheritance *****/
public class CylinderEnemyController : EnemyController
{
    void Start()
    {
        enemyPoints = 15;
        enemySpeed = 10.0f;
        speedAmplifier = 1f;// Mathf.Exp(0.5f);
        enemyRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
    }

    /***** Polymorphism *****/
    public override void Movement()
    {
        //enemySpeed = Mathf.Abs(Mathf.Sin(Time.time)) * speedAmplifier;
        base.Movement();
    }
}
