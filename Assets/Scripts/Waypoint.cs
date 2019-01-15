using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;
    [SerializeField] Tower towerMesh;

    const int gridSize = 10;
    public Vector2Int GetGridPos => new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize)
        );

    public int GridSize => gridSize;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                Instantiate(towerMesh, transform.position, Quaternion.identity);
                isPlaceable = false;
                print(gameObject.name);
            }
            else
            {
                print("not placeable");
            }
        }
    }
}
