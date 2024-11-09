using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab5Zad3 : MonoBehaviour
{
    public List<Vector3> waypoints = new List<Vector3>(); 
    public float speed = 15.0f;                           

    private int currentWaypointIndex = 0;                  
    private bool movingForward = true;                 
    private bool playerOnPlatform = false;                

    private void Start()
    {
        if (waypoints.Count > 0)
        {
            waypoints.Insert(0, transform.position);
        }
    }

    private void Update()
    {
        if (playerOnPlatform && waypoints.Count > 1)
        {
            MovePlatform();
        }
    }

    private void MovePlatform()
    {
        Vector3 targetPosition = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (movingForward)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Count)
                {
                    movingForward = false;
                    currentWaypointIndex = waypoints.Count - 2; 
                }
            }
            else
            {
                currentWaypointIndex--;
                if (currentWaypointIndex < 0)
                {
                    movingForward = true;
                    currentWaypointIndex = 1; 
                }
            }
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
