using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopChopRTS : MonoBehaviour {

    private GameRTSController gameRTSController;
    private Camera mainCamera;

    private void Awake() {
        mainCamera = Camera.main;
        Application.targetFrameRate = 100;
        gameRTSController = GetComponent<GameRTSController>();
    }

    private void Update() {
        // Test Orders
        if (Input.GetMouseButtonDown(1)) {
            // Right Mouse Button Click
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit raycastHit)) {
                // Raycast hit something

                // Normal move action
                Action<UnitRTS> unitAction = (UnitRTS unit) => unit.NormalMoveTo(Mouse3D.GetMouseWorldPosition());

                // Execute Action
                foreach (UnitRTS unit in gameRTSController.GetSelectedUnitList()) {
                    unitAction(unit);
                }
            }
        }
    }

}
