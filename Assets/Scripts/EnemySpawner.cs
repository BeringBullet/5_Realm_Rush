﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform parentFolder;
    [SerializeField] Text EnemySpawnedText;
    [SerializeField] AudioClip spawnedEnemySFX;

    int score;
    float secondsBetweenSpawns;
    bool isrunning = true;
    // Start is called before the first frame update
    void Start()
    {
        var prop = FindObjectOfType<Properties>();
        secondsBetweenSpawns = prop.SecondsBetweenSpawns;
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (isrunning)
        {
            var enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.transform.parent = parentFolder;
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            AddScore();
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void AddScore()
    {
        score++;
        EnemySpawnedText.text = score.ToString();
    }
}
