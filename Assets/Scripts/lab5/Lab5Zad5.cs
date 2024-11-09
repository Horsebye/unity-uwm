using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab5Zad5 : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Contact with obstacle started.");
        }
    }
}
