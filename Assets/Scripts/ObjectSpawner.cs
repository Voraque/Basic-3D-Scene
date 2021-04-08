using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] Transform[] buildings;
    [SerializeField] Vector3 buildingSize = Vector3.one;
    float buildingScaleFactor = 0.5f;
    
    Transform buildingInstance;
    Vector2 offset = new Vector2(0.5f, 0.5f);
    int citySize;

    public void updateCitySize(string citySizeString) {
        citySize = Convert.ToInt32(citySizeString);
    }

    public void GenerateCity() {
        for (int x = 0; x < citySize; x++) {
            for (int y = 0; y < citySize; y++) {
                buildingInstance = Instantiate(
                    buildings[UnityEngine.Random.Range(0, buildings.Length)]);
                buildingInstance.localPosition = new Vector3(x + offset.x, 0f, y + offset.y);
                buildingInstance.localScale = buildingSize * buildingScaleFactor;
            }
        }
    }
}
