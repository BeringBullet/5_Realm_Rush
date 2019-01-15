using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectileParticle;

    //State
    Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
        setTargetEnemy();

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

    private void setTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) return;

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = getClosest(closestEnemy, testEnemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform getClosest(Transform TransformA, Transform TransformB)
    {
        var distToA = Vector3.Distance(transform.position, TransformA.position);
        var distToB = Vector3.Distance(transform.position, TransformB.position);

        if (distToA < distToB)
            return TransformA;

        return TransformB;
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
