using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;

public class GridBuildingSystem : MonoBehaviour {

    public static GridBuildingSystem Instance { get; private set ; }

    private GridXZ<PathNode> grid;
    private Pathfinding pathFinding;

    [SerializeField] private GameObject sphereTest;
    [SerializeField] private CharacterPathfindingMovementHandler characterPathfinding;
    [SerializeField] private bool debugPath = false;

    private void Awake() {
        Instance = this;
        int gridWidth = 20;
        int gridHeight = 20;
        float cellSize = 2f;
        pathFinding = new Pathfinding(gridWidth, gridHeight, cellSize);
    }

    private void Start() {
        characterPathfinding = null;
    }

    public void setSelectedCharacter (CharacterPathfindingMovementHandler characterPathfinding) {
        this.characterPathfinding = characterPathfinding;
    }

    private void Update()
    {
        MoveSelectedCharacter();
        DesignateSelectedUnitPath();
    }

    private void MoveSelectedCharacter()
    {
        if (Input.GetMouseButtonDown(1) && characterPathfinding != null)
        {
            Vector3 mouseWorldPosition = Mouse3D.GetMouseWorldPosition();
            pathFinding.GetGrid().GetXZ(mouseWorldPosition, out int x, out int z);
            int characterPosX = (int)characterPathfinding.gameObject.transform.position.x;
            int characterPosZ = (int)characterPathfinding.gameObject.transform.position.z;
            characterPathfinding.SetTargetPosition(mouseWorldPosition);
        }
    }

    private void DesignateSelectedUnitPath() {
        if (characterPathfinding != null) {
            Vector3 mouseWorldPosition = Mouse3D.GetMouseWorldPosition();
            pathFinding.GetGrid().GetXZ(mouseWorldPosition, out int x, out int z);
            int characterPosX = (int)characterPathfinding.gameObject.transform.position.x;
            int characterPosZ = (int)characterPathfinding.gameObject.transform.position.z;
            List<PathNode> path = pathFinding.FindPath(characterPosX, characterPosZ, x, z);
            if (path != null)
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    // print(path[i].x + " " + path[i].z);
                    Instantiate(sphereTest, new Vector3(path[i].x, 1, path[i].z), transform.rotation);
                }
            }
        }
    }

    public CharacterPathfindingMovementHandler getCurrentCharacterPathfinding() {
        return characterPathfinding;
    }

}
