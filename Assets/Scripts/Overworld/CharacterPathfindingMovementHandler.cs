using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class CharacterPathfindingMovementHandler : MonoBehaviour {

    [SerializeField] private float speed = 1f;
    [SerializeField] private List<Vector3> pathVectorList;

    private int currentPathIndex;
    private UnitAnimation unitAnimation;

    private void Awake() {
        unitAnimation = GetComponent<UnitAnimation>();
    }

    private void Start() {
        StopMoving();
    }

    private void Update() {
        HandleMovement();
    }
    
    private void HandleMovement() {
        if (pathVectorList != null) {
            Vector3 targetPosition = pathVectorList[currentPathIndex];
            if (Vector3.Distance(transform.position, targetPosition) > .01f) {
                Vector3 moveDir = (targetPosition - transform.position).normalized;
                unitAnimation.SetMoveVector(moveDir);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            } else {
                currentPathIndex++;
                if (currentPathIndex >= pathVectorList.Count) {
                    StopMoving();
                    unitAnimation.SetMoveVector(Vector3.zero);
                }
            }
        } else {
            unitAnimation.SetMoveVector(Vector3.zero);
        }
    }

    private void StopMoving() {
        pathVectorList = null;
    }

    public Vector3 GetPosition() {
        return transform.position;
    }

    public void SetTargetPosition(Vector3 targetPosition) {
        currentPathIndex = 0;
        pathVectorList = Pathfinding.Instance.FindPath(GetPosition(), targetPosition);

        if (pathVectorList != null && pathVectorList.Count > 1) {
            pathVectorList.RemoveAt(0);
        }
    }

    public List<Vector3> GetPathVectorList() {
        return pathVectorList;
    }

}