using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab5Zad4 : MonoBehaviour
{
    private bool playerOnPlatform = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MoveWithCharacterController playerController = other.GetComponent<MoveWithCharacterController>();

            if (playerController != null)
            {
                playerController.Jump();
            }
        }
    }
}
