using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    private GridXZ<PathNode> grid;

    public Pathfinding(int width, int height) {
        grid = new GridXZ<PathNode>(width, height, 10f, Vector3.zero, (GridXZ<PathNode> g, int x, int y) => new PathNode(g, x, y));
    }
}
