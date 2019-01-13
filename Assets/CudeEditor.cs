﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CudeEditor : MonoBehaviour
{
    [Range(1f, 20f)] [SerializeField] float gridSize = 10f;

    TextMesh textMesh;
    // Update is called once per frame
    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = $"{snapPos.x / gridSize}, {snapPos.z / gridSize}";

        transform.position = new Vector3(snapPos.x, 0, snapPos.z);
    }
}