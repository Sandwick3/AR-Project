using UnityEngine;

public class GrayscaleToggle : MonoBehaviour
{
    public GameObject cube;  // The 3D cube
    public Material grayscaleMaterial;  // Grayscale material
    public Material defaultMaterial;  // Original (non-grayscale) material
    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();  // Camera renderer or assigned one
    }

    void Update()
    {
        // Check if the camera is inside the cube
        if (IsInsideCube())
        {
            renderer.material = defaultMaterial;  // Disable grayscale
        }
        else
        {
            renderer.material = grayscaleMaterial;  // Enable grayscale
        }
    }

    bool IsInsideCube()
    {
        // Get the cube's boundaries
        Bounds cubeBounds = cube.GetComponent<Renderer>().bounds;
        return cubeBounds.Contains(Camera.main.transform.position);  // Check if camera is inside
    }
}
