using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***** Inheritance *****/
public class CubeEnemyController : EnemyController
{ 
    void Start()
    {
        enemyPoints = 20;
        enemySpeed = 10.0f;
        speedAmplifier = Mathf.Log10(50);
        enemyRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
    }

    /***** Polymorphism *****/
    public override void Movement()
    {
        //enemySpeed = Mathf.Abs(Mathf.Cos(Time.time))*speedAmplifier;
        base.Movement();
    }
}
