using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120)] [SerializeField] float secondsBetweenSpawns = 4f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform parentFolder;
    [SerializeField] Text EnemySpawnedText;
    int score;

    bool isrunning = true;
    // Start is called before the first frame update
    void Start() => StartCoroutine(SpawnEnemy());

    IEnumerator SpawnEnemy()
    {
        while (isrunning)
        {
            var enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.transform.parent = parentFolder;
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
