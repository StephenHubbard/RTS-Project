using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehaviorNormal : MonoBehaviour, IUnitBehaviour {

    private UnitRTS unit;

    private void Awake() {
        unit = GetComponent<UnitRTS>();
    }

    public void UpdateBehaviour() {
        if (!unit.IsStopped()) {
            if (unit.GetNavMeshAgent().remainingDistance <= .5f) {
                unit.StopMoving();
            }
        }
    }

    public void MoveTo(Vector3 destinationPosition) {
        unit.SetActiveBehaviour(this);
        unit.SetDestination(destinationPosition);
    }

}
