using System.Collections.Generic;
using UnityEngine;

namespace Map.Grass
{
    public class GrassSpawner : MonoBehaviour
    {
        public GameObject[] grassObjects; // Manually placed grass objects

        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main;

            foreach (GameObject grassObject in grassObjects)
            {
                // Apply any optimization settings to the grass object's renderer
                MeshRenderer grassRenderer = grassObject.GetComponent<MeshRenderer>();
                if (grassRenderer != null)
                {
                    grassRenderer.enabled = false; // Disable rendering by default
                }
            }
        }

        private void Update()
        {
            foreach (GameObject grassObject in grassObjects)
            {
                SetGrassVisibility(grassObject);
            }
        }

        private void SetGrassVisibility(GameObject grassObject)
        {
            if (IsVisibleFromCamera(grassObject))
            {
                MeshRenderer grassRenderer = grassObject.GetComponent<MeshRenderer>();
                if (grassRenderer != null)
                {
                    grassRenderer.enabled = true; // Enable rendering if visible
                }
            }
            else
            {
                MeshRenderer grassRenderer = grassObject.GetComponent<MeshRenderer>();
                if (grassRenderer != null)
                {
                    grassRenderer.enabled = false; // Disable rendering if not visible
                }
            }
        }

        private bool IsVisibleFromCamera(GameObject obj)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(mainCamera), renderer.bounds);
            }
            return false;
        }
    }
}