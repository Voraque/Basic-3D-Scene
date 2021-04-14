using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectSpawner : MonoBehaviour
{
    int citySize;
    List<Building> buildingsList = new List<Building>();
    [SerializeField] Building[] buildingPrefabs;

    public void updateCitySize(string citySizeString) {
        citySize = Convert.ToInt32(citySizeString);
    }

    public void GenerateCity() {
        //Check if city was already generated
        if (buildingsList.Count != 0) {
            DestroyCity();
        }

        for (int x = 0; x < citySize; x++) {
            for (int y = 0; y < citySize; y++) {
                Building buildingReference = Instantiate(
                    buildingPrefabs[UnityEngine.Random.Range(0, buildingPrefabs.Length)]);
                buildingReference.transform.SetParent(transform, false);
                buildingReference.SetBuildingLocation(x, y);
                buildingsList.Add(buildingReference);
            }
        }
    }

    public void DestroyCity() {
        foreach (Building building in buildingsList) {
            Destroy(building.gameObject, building.moveDuration);
        }
        buildingsList.Clear();
    }
}

