using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrow : MonoBehaviour
{
    [SerializeField] private GameObject[] arrowChildren;
    [SerializeField] private float destroyFloatTimer = 1f;

    private void Start() {
        Invoke("SelfDestroy", destroyFloatTimer);
    }

    private void SelfDestroy() {
        Destroy(gameObject);
    }

}
