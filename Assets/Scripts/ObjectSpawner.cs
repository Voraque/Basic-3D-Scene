using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] Transform[] buildingPrefabs;
    [SerializeField] Vector3 buildingSize = Vector3.one;
    
    int citySize;
    float buildingScaleFactor = 0.5f;
    List<GameObject> buildings = new List<GameObject>();
    Vector2 offset = new Vector2(0.5f, 0.5f);
    
    Transform buildingInstance;

    public void updateCitySize(string citySizeString) {
        citySize = Convert.ToInt32(citySizeString);
    }

    public void GenerateCity() {
        for (int x = 0; x < citySize; x++) {
            for (int y = 0; y < citySize; y++) {
                buildingInstance = Instantiate(
                    buildingPrefabs[UnityEngine.Random.Range(0, buildingPrefabs.Length)]);
                buildingInstance.localPosition = new Vector3(x + offset.x, 0f, y + offset.y);
                buildingInstance.localScale = buildingSize * buildingScaleFactor;
                buildings.Add(buildingInstance.gameObject);
            }
        }
    }

    public void DestroyCity() {
        foreach (UnityEngine.Object buildingReference in buildings) {
            Destroy(buildingReference);
        }
    }
}
