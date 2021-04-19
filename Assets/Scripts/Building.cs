using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] Vector3 buildingSize = Vector3.one;

    public float moveDuration { get; set; } = 3f;
    Vector2 offset = new Vector2(0.5f, 0.5f);
    float[] buildingRotationOptions = new float[] {0f, 90f, 180f, 270f};

    public void SetBuildingLocation(int x, int y) {
        Vector3 direction = new Vector3(x + offset.x, 0f, y + offset.y);
        Quaternion target = Quaternion.Euler(
            transform.rotation.x, buildingRotationOptions[Random.Range(0, 3)], transform.rotation.z);
        transform.localPosition = direction;
        transform.localRotation = target;
    }

    public void DestroyBuilding() {
        Destroy(gameObject);
    }
}
