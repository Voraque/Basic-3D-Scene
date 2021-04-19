using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UICityController : MonoBehaviour {
    [SerializeField] TextMeshProUGUI widthText;
    [SerializeField] TextMeshProUGUI heightText;

    ObjectSpawner objectSpawner;
    PerlinGenerator perlinGenerator;

    private void Start() {
        objectSpawner = FindObjectOfType<ObjectSpawner>();
        perlinGenerator = FindObjectOfType<PerlinGenerator>();
    }
    public void updateCityWidth(float newCityWidth) {
        objectSpawner.cityWidth = (int)newCityWidth;
        widthText.text = $"Width:  {newCityWidth}";
        perlinGenerator.width = (int)newCityWidth;
        
    }

    public void updateCityHeight(float newCityHeight) {
        objectSpawner.cityHeight = (int)newCityHeight;
        heightText.text = $"Height: {newCityHeight}";
        perlinGenerator.height = (int)newCityHeight;
    }
}
