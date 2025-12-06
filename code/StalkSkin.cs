using UnityEngine;

public class StalkSkin : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public int materialIndexToChange = 0;

    void Start()
    {
        if (skinnedMeshRenderer == null)
        {
            skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
            if (skinnedMeshRenderer == null)
            {
                Debug.LogError("SkinnedMeshRenderer component not found on the GameObject.");
                return;
            }
        }

        SetRandomMaterialColor();
    }

    public void SetRandomMaterialColor()
    {
        if (skinnedMeshRenderer.materials.Length == 0)
        {
            Debug.LogWarning("The SkinnedMeshRenderer has no materials assigned.");
            return;
        }

        if (materialIndexToChange < 0 || materialIndexToChange >= skinnedMeshRenderer.materials.Length)
        {
            Debug.LogWarning("Invalid material index provided. Setting to random material.");
            materialIndexToChange = Random.Range(0, skinnedMeshRenderer.materials.Length);
        }

        Material[] materials = skinnedMeshRenderer.materials;

        Color randomColor = new Color(Random.value, Random.value, Random.value);

        materials[materialIndexToChange].color = randomColor;

        // For setting the color of the entire material:
        // materials[materialIndexToChange].SetColor("_Color", randomColor);

        skinnedMeshRenderer.materials = materials;
    }
}
