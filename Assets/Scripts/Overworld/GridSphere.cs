using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSphere : MonoBehaviour
{
    private void Start() {
        Invoke("SelfDestroy", 2f);
    }

    private void SelfDestroy() {
        Destroy(gameObject);
    }
}
