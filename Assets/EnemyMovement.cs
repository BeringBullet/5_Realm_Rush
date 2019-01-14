using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;
    // Start is called before the first frame update
    void Start()
    {
       //StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        print("Starting patrol...");
        foreach (var item in path)
        {
            print($"Visiting block {item}");
            transform.position = item.transform.position;
            yield return new WaitForSeconds(1f);
        }
        print("Ending patrol...");
    }
}
