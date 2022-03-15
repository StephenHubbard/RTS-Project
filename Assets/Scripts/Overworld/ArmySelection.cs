using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmySelection : MonoBehaviour
{
    [SerializeField] GameObject selectedSprite;

    private bool isSelected;
    private CharacterPathfindingMovementHandler pathFinding;

    private void Awake() {
        pathFinding = GetComponent<CharacterPathfindingMovementHandler>();
    }

    private void Start() {
        SetIsSelected(false);
    }

    private void OnMouseDown() {
        CharacterPathfindingMovementHandler previousSelected = GridBuildingSystem.Instance.getCurrentCharacterPathfinding();
        if (previousSelected) {
            previousSelected.GetComponent<ArmySelection>().SetIsSelected(false);
        }
        this.SetIsSelected(true);
    }

    public void SetIsSelected(bool isSelected) {
        this.isSelected = isSelected;
        selectedSprite.SetActive(isSelected);
        GridBuildingSystem.Instance.setSelectedCharacter(pathFinding);
    }
}
