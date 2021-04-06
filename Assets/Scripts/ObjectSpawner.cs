using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] Transform cube;
    [SerializeField] int numberOfCubes;


    private void Start() {
        for (int i = 0; i < numberOfCubes; i++) {
            Transform cubeInstance = Instantiate(cube);
            cubeInstance.localPosition = Vector3.right * i;
        }
    }
}
