using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab5Zad2 : MonoBehaviour
{
    public float speed = 2.0f;

    private float openOffset = 5.0f; 
    private Vector3 closedPosition;   
    private Vector3 openPosition;     
    private bool isOpen = false;      

    private void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + Vector3.right * openOffset;
    }

    private void Update()
    {
        if (isOpen)
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosition, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, closedPosition, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpen = false;
        }
    }
}
