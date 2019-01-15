using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public Waypoint exploredFrom;

    const int gridSize = 10;
    public Vector2Int GetGridPos => new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize)
        );

    public int GridSize => gridSize;

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer =  transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}
