using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;

public class GridBuildingSystem : MonoBehaviour {

    private GridXZ<PathNode> grid;
    private Pathfinding pathFinding;

    [SerializeField] private GameObject sphereTest;

    private void Awake() {
        int gridWidth = 10;
        int gridHeight = 10;
        float cellSize = 1f;
        // grid = new GridXZ<PathNode>(gridWidth, gridHeight, cellSize, new Vector3(0, 0, 0), (GridXZ<PathNode> g, int x, int z) => new PathNode(g, x, z));
        pathFinding = new Pathfinding(gridWidth, gridHeight, cellSize);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
          Vector3 mouseWorldPosition = Mouse3D.GetMouseWorldPosition();
          pathFinding.GetGrid().GetXZ(mouseWorldPosition, out int x, out int z);
          List<PathNode> path = pathFinding.FindPath(0, 0, x, z);
            if (path != null) {
                for (int i = 0; i < path.Count - 1; i++) {
                    Instantiate(sphereTest, new Vector3(path[i+1].x + .5f, 0, path[i+1].z +.5f), transform.rotation);
                    Debug.DrawLine(new Vector3(path[i].x + .5f, 0, path[i].z + .5f), new Vector3(path[i+1].x + .5f, 0, path[i+1].z +.5f), Color.green, 2f);
                }
            }
        }
    }

}
