using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] public Waypoint startWaypoint, endWaypoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        PathFind();
    }

    private void PathFind()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning)
        {
            var searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            print($"Searching from: {searchCenter}");
            HaltIfEndFount(searchCenter);
            ExploreNeighbours(searchCenter);
        }
        //work out path
        print("Finished pathfinding?");
    }

    private void HaltIfEndFount(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("Searching from end node, therefore stapping");
            isRunning = false;
        }
    }

    private void ExploreNeighbours(Waypoint from)
    {
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = from.GetGridPos + direction;
            try
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
            catch (Exception)
            {
                // do nothing
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (!neighbour.isExplored)
        {
            neighbour.SetTopColor(Color.yellow);
            queue.Enqueue(neighbour);
            print($"Queueing {neighbour}");
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.blue);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            Vector2Int gridPos = waypoint.GetGridPos;
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning($"Skipping Overlapping block {waypoint}");
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }
    }
}
