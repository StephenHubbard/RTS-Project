﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraTarget : MonoBehaviour {

    public enum Axis {
        XZ,
        XY,
    }

    [SerializeField] private Axis axis = Axis.XZ;
    [SerializeField] private float moveSpeed = 50f;
    [SerializeField] private Volume postProcessingVolume;

    private float cameraY;
    private DepthOfField depthOfField;
    private float depthOfFieldOffset = 13.5f;

    private void Awake() {
        cameraY = transform.position.y;

        postProcessingVolume.profile.TryGet<DepthOfField>(out depthOfField);
    }

    private void Update() {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W)) {
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.S)) {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A)) {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D)) {
            moveX = +1f;
        }

        Vector3 moveDir;

        switch (axis) {
            default:
            case Axis.XZ:
                moveDir = new Vector3(moveX, 0, moveY).normalized;
                break;
            case Axis.XY:
                moveDir = new Vector3(moveX, moveY).normalized;
                break;
        }
        
        if (moveX != 0 || moveY != 0) {
            // Not idle
        }

        if (axis == Axis.XZ) {
            //moveDir = UtilsClass.ApplyRotationToVectorXZ(moveDir, 30f);
        }

        transform.position += moveDir * moveSpeed * Time.deltaTime;


        float zoomSpeed = 1f;
        cameraY += -Input.mouseScrollDelta.y * zoomSpeed;
        cameraY = Mathf.Clamp(cameraY, -3f, 17);
        transform.position = new Vector3(transform.position.x, cameraY, transform.position.z);

        depthOfField.focusDistance.value = (cameraY * .5f) + depthOfFieldOffset;
    }

}
