using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkyboxChanger : MonoBehaviour
{
    [SerializeField] private List<Material> skyboxMaterials;

    void Start()
    {
        // Change the skybox material
        ChangeSkyboxMaterial();
    }

    public void ResetScene()
    {
        // Reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    private void ChangeSkyboxMaterial()
    {
        if (skyboxMaterials.Count > 0)
        {
            // Randomly select a skybox material from the list
            Material selectedSkybox = skyboxMaterials[Random.Range(0, skyboxMaterials.Count)];

            // Set the selected skybox material
            RenderSettings.skybox = selectedSkybox;
        }
        else
        {
            Debug.LogWarning("No skybox materials in the list.");
        }
    }
}
