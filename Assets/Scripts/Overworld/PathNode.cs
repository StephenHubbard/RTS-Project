using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode {

    private GridXZ<PathNode> grid;
    public int x;
    public int z;

    public int gCost;
    public int hCost;
    public int fCost;

    public PathNode cameFromNode;

    public PathNode(GridXZ<PathNode> grid, int x, int z) {
        this.grid = grid;
        this.x = x;
        this.z = z;
    }

    public override string ToString() {
        return x + "," + z;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }
    
}