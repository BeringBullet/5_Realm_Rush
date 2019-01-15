using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerMesh;
    [SerializeField] Transform towerParentTransform;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        if (towerQueue.Count < towerLimit)
        {
            InstantiateTower(baseWaypoint);
        }
        else
        {
            MoveTower(baseWaypoint);
        }
    }

    private void InstantiateTower(Waypoint baseWaypoint)
    {
        var tower = Instantiate(towerMesh, baseWaypoint.transform.position, Quaternion.identity);
        tower.transform.parent = towerParentTransform;
        tower.currentBase = baseWaypoint;
        tower.currentBase.isPlaceable = false;
        towerQueue.Enqueue(tower);
    }

    private void MoveTower(Waypoint baseWaypoint)
    {
        var tower = towerQueue.Dequeue();
        tower.currentBase.isPlaceable = true;
        tower.currentBase = baseWaypoint;
        tower.currentBase.isPlaceable = false;
        tower.transform.position = baseWaypoint.transform.position;
        towerQueue.Enqueue(tower);
    }
}
