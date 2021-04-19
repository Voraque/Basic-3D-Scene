using UnityEngine;

public class PerlinGenerator : MonoBehaviour
{

    public int width { get; set; } = 50;
    public int height { get; set; } = 50;

    [SerializeField] int scale = 4;
    [SerializeField] int offsetX;
    [SerializeField] int offsetY;

    public Texture2D Texture => (Texture2D)GetComponent<Renderer>().material.mainTexture;

    public void RandomizeNoise() {
        offsetX = Random.Range(0, 9999);
        offsetY = Random.Range(0, 9999);
        OnValidate();
    }
    void OnValidate()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.sharedMaterial.mainTexture = GenerateTexture();
    }

    private Texture2D GenerateTexture() {
        Texture2D texture = new Texture2D(width, height);
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
        return texture;
    }

    private Color CalculateColor(int x, int y) {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }
}
