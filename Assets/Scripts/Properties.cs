using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties : MonoBehaviour
{
    [SerializeField] int enemyHealth= 10;
    [Range(0.1f, 120)] [SerializeField] float secondsBetweenSpawns = 2f;
    [Range(.1f, 2f)] [SerializeField] float movementPeriod = .5f;
    [Range(.1f, 50f)] [SerializeField] float attackRange  = 10f;

    public int EnemyHealth => enemyHealth;
    public float AttackRange => attackRange;
    public float SecondsBetweenSpawns => secondsBetweenSpawns;
    public float MovementPeriod => movementPeriod;
}
