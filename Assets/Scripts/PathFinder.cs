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
    Waypoint searchCenter;

    List<Waypoint> path = new List<Waypoint>();

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            CalculatePath();
        }
        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreathFirstSearch();
        CreatePath();
    }

    private void CreatePath()
    {
        path.Add(endWaypoint);
        Waypoint previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(startWaypoint);
        path.Reverse();
    }

    private void BreathFirstSearch()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            HaltIfEndFount();
            ExploreNeighbours();
        }
        //work out path
    }

    private void HaltIfEndFount()
    {
        if (searchCenter == endWaypoint)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos + direction;
            if (grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
            //do nothing
        }
        else
        {
            neighbour.exploredFrom = searchCenter;
            queue.Enqueue(neighbour);
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
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
