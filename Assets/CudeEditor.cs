using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Waypoint))]
[SelectionBase]
public class CudeEditor : MonoBehaviour
{
    Waypoint waypoint;
   
    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    // Update is called once per frame
    void Update()
    {
        SnapToGrid();
        UpdateLabel();

    }

    private void SnapToGrid()
    {
        transform.position = new Vector3(waypoint.GetGridPos.x * waypoint.GridSize, 0, waypoint.GetGridPos.y * waypoint.GridSize);
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = $"{waypoint.GetGridPos.x }, {waypoint.GetGridPos.y }";
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
