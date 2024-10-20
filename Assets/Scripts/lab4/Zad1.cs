using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    public int numObjects = 5;
    public GameObject block;
    public GameObject plane;
    public Material[] materials;

    void Start()
    {
        if (plane != null)
        {
            Renderer planeRenderer = plane.GetComponent<Renderer>();
            if (planeRenderer != null)
            {
                Bounds platformBounds = planeRenderer.bounds;

                for (int i = 0; i < numObjects; i++)
                {
                    float posX = UnityEngine.Random.Range(platformBounds.min.x, platformBounds.max.x);
                    float posZ = UnityEngine.Random.Range(platformBounds.min.z, platformBounds.max.z);
                    float posY = platformBounds.max.y + 1;
                    positions.Add(new Vector3(posX, posY, posZ));
                }

                StartCoroutine(GenerujObiekt());
            }
            else
            {
                Debug.LogError("The plane GameObject does not have a Renderer component.");
            }
        }
        else
        {
            Debug.LogError("Plane GameObject is not assigned.");
        }
    }

    void Update()
    {
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("Coroutine started");

        for (int i = 0; i < numObjects; i++)
        {
            Debug.Log($"Generating object {i + 1} of {numObjects}");

            GameObject newBlock = Instantiate(this.block, this.positions[i], Quaternion.identity);

            if (materials.Length > 0)
            {
                Material randomMaterial = materials[UnityEngine.Random.Range(0, materials.Length)];
                newBlock.GetComponent<Renderer>().material = randomMaterial;
            }

            yield return new WaitForSeconds(this.delay);
        }

        Debug.Log("Coroutine finished");
    }
}

