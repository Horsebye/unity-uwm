using System;
using UnityEngine;

public class Lab5Zad1 : MonoBehaviour
{
    private Vector3 startPoint;    
    private Vector3 endPoint;        
    public float speed = 2.0f;         

    private Vector3 targetPosition;    
    private bool playerOnPlatform = false; 

    private void Start()
    {
        startPoint = transform.position;               
        endPoint = startPoint + Vector3.right * 80.0f;
        targetPosition = endPoint;
    }

    private void Update()
    {
        if (playerOnPlatform)
        {
            MovePlatform();
        }
    }

    private void MovePlatform()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = targetPosition == startPoint ? endPoint : startPoint;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = false;
        }
    }
}
