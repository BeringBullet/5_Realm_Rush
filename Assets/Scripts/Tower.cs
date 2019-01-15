using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectileParticle;
    // Update is called once per frame
    void Update()
    {
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            shoot(false);
        }
    }

    private void FireAtEnemy()
    {
        float distance = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distance <= attackRange)
        {
            shoot(true);
        }
        else
        {
            shoot(false);
        }
    }

    private void shoot(bool isAcrive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isAcrive;
    }
}
