using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour
{
   
    [SerializeField] Building[] smallBuildings;
    [SerializeField] Building[] mediumBuildings;
    [SerializeField] Building[] largeBuildings;
    [SerializeField] Building[] parkTiles;

    [SerializeField, Range(0f, 1f)] float parkBreakPoint = 0.2f;
    [SerializeField, Range(0f, 1f)] float smallBreakPoint = 0.4f;
    [SerializeField, Range(0f, 1f)] float mediumBreakPoint = 0.5f;
    [SerializeField] PerlinGenerator perlinGenerator;

    List<Building> buildingsList = new List<Building>();
    Building[] buildingArray;
    public int cityWidth { get; set; } = 25;
    public int cityHeight { get; set; } = 25;


    public void GenerateCity() {

        perlinGenerator.RandomizeNoise();

        if (buildingsList.Count != 0) {
            DestroyCity();
        }

        for (int x = 0; x < cityWidth; x++) {
            for (int y = 0; y < cityHeight; y++) {
                buildingArray = SelectBuildings(x, y);
                Building buildingReference = Instantiate(
                    buildingArray[UnityEngine.Random.Range(0, buildingArray.Length)]);
                buildingReference.transform.SetParent(transform, false);
                buildingReference.SetBuildingLocation(x, y);
                buildingsList.Add(buildingReference);
            }
        }
    }

    private Building[] SelectBuildings(int x, int y) {
        float pixelValue = perlinGenerator.Texture.GetPixel(x, y).grayscale;
        if (pixelValue < parkBreakPoint) {
            buildingArray = parkTiles;
        }
        else if (pixelValue < smallBreakPoint) {
            buildingArray = smallBuildings;
        }
        else if (pixelValue < mediumBreakPoint) {
            buildingArray = mediumBuildings;
        }
        else {
            buildingArray = largeBuildings;
        }
        return buildingArray;
    }

    public void DestroyCity() {
        foreach (Building building in buildingsList) {
            Destroy(building.gameObject);
        }
        buildingsList.Clear();
    }
}

