using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitVisual : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private UnitRTS unit;

    private void Awake() {
        unit = GetComponent<UnitRTS>();
    }

    public void UnitIsRunning(bool isRunning) {
        animator.SetBool("isRunning", isRunning);
    }
}
