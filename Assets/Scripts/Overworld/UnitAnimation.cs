using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimation : MonoBehaviour
{
    private Vector3 lastMoveVector;
    [SerializeField] private Animator animator;


    public void SetMoveVector(Vector3 moveVector) {
        if (moveVector == Vector3.zero) {
            // Idle
            animator.SetBool("isRunning", false);
        } else {
            // Moving
            animator.SetBool("isRunning", true);
            transform.rotation = Quaternion.LookRotation(moveVector);
            lastMoveVector = moveVector;
        }
    }

    public Vector3 GetLastMoveVector() {
        return lastMoveVector;
    }
}
