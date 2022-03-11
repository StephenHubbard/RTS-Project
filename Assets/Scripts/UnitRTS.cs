using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using CodeMonkey.Utils;

public class UnitRTS : MonoBehaviour
{

    public event EventHandler OnIsSelectedChanged;
    public event EventHandler OnStartedMoving;
    public event EventHandler OnStoppedMoving;

    [SerializeField] GameObject selectedSprite;
    [SerializeField] private IUnitBehaviour unitBehaviour;
    private NavMeshAgent navMeshAgent;
    private bool isSelected;

    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        unitBehaviour = GetComponent<UnitBehaviorNormal>();
    }

    private void Start() {
        SetIsSelected(false);
    }

    private void Update()
    {
        unitBehaviour.UpdateBehaviour();
    }

    // public void SetIsSelected(bool selected) {
    //     selectedSprite.SetActive(selected);
    // }

    public void StopMoving()
    {
        navMeshAgent.isStopped = true;
        OnStoppedMoving?.Invoke(this, EventArgs.Empty);
    }

    public bool IsStopped()
    {
        return navMeshAgent.isStopped;
    }
    
    public NavMeshAgent GetNavMeshAgent() {
        return navMeshAgent;
    }

    public void SetActiveBehaviour(IUnitBehaviour unitBehaviour) {
        this.unitBehaviour = unitBehaviour;
    }

    public void SetDestination(Vector3 destinationPosition, float stoppingDistance = .5f) {
        navMeshAgent.SetDestination(destinationPosition);
        navMeshAgent.stoppingDistance = stoppingDistance;
        navMeshAgent.isStopped = false;
        OnStartedMoving?.Invoke(this, EventArgs.Empty);
    }

    public IUnitBehaviour GetActiveBehaviour() {
        return unitBehaviour;
    }

    public bool GetIsSelected() => isSelected;

    public void SetIsSelected(bool isSelected) {
        this.isSelected = isSelected;
        selectedSprite.SetActive(isSelected);
        OnIsSelectedChanged?.Invoke(this, EventArgs.Empty);
    }

    public void SetStateNormal() {
        GetComponent<UnitBehaviorNormal>().MoveTo(GetPosition());
    }

    public void NormalMoveTo(Vector3 destinationPosition) {
        GetComponent<UnitBehaviorNormal>().MoveTo(destinationPosition);
    }

    public Vector3 GetPosition() {
        return transform.position;
    }
}
