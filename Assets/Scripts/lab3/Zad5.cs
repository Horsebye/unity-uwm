using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad5 : MonoBehaviour
{
    public GameObject cube; 
    public int numberOfCubes = 10;
    public GameObject plane;

    private List<Vector3> usedPositions = new List<Vector3>();

    void Start()
    {
        GenerateCubes();
    }

    void GenerateCubes()
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 position = GetRandomPosition();
            Debug.Log("New position: " + position);
            while (usedPositions.Contains(position))
            {
                position = GetRandomPosition();
            }
            usedPositions.Add(position);
            Instantiate(cube, position, Quaternion.identity);
        }
    }

    Vector3 GetRandomPosition()
    {
        Renderer planeRenderer = plane.GetComponent<Renderer>();
        Bounds planeBounds = planeRenderer.bounds;

        float x = UnityEngine.Random.Range(planeBounds.min.x, planeBounds.max.x);
        float z = UnityEngine.Random.Range(planeBounds.min.z, planeBounds.max.z);
        return new Vector3(x, planeBounds.max.y + 0.5f, z);
    }
}
