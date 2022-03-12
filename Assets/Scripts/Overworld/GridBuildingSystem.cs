using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridBuildingSystem : MonoBehaviour {

    private GridXZ<PathNode> grid;

    private void Awake() {
        int gridWidth = 10;
        int gridHeight = 10;
        float cellSize = 1f;
        grid = new GridXZ<PathNode>(gridWidth, gridHeight, cellSize, new Vector3(0, 0, 0), (GridXZ<PathNode> g, int x, int z) => new PathNode(g, x, z));
    }

    public class PathNode {

        private GridXZ<PathNode> grid;
        private int x;
        private int z;

        public PathNode(GridXZ<PathNode> grid, int x, int z) {
            this.grid = grid;
            this.x = x;
            this.z = z;
        }

        public override string ToString() {
          return x + ", " + z;
        }
    }
}
