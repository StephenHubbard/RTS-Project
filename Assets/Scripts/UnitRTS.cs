using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRTS : MonoBehaviour
{
    [SerializeField] GameObject selectedSprite;

    private void Awake() {
        SetIsSelected(false);
    }

    public void SetIsSelected(bool selected) {
        selectedSprite.SetActive(selected);
    }
}
