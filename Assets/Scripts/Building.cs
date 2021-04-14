using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] Vector3 buildingSize = Vector3.one;
    [SerializeField] Ease movementEase = Ease.Linear;

    public float moveDuration { get; set; } = 3f;
    float buildingScaleFactor = 0.5f;
    Vector2 offset = new Vector2(0.5f, 0.5f);
  
    public void SetBuildingLocation(int x, int y) {
        Vector3 direction = new Vector3(x + offset.x, 0f, y + offset.y);
        transform.localScale = buildingSize * buildingScaleFactor;
        transform.DOMove(direction, moveDuration);
    }

    public void DestroyBuilding() {
        Destroy(gameObject);
    }
}
