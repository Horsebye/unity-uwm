using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad2 : MonoBehaviour
{
    public float speed = 2.0f;
    private Rigidbody rb;
    private bool isMovingForward = true;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingForward)
        {
            rb.MovePosition(transform.position + Vector3.right * speed * Time.deltaTime);
            if (Vector3.Distance(startPosition, transform.position) >= 10f)
            {
                isMovingForward = false;
            }
        }
        else
        {
            rb.MovePosition(transform.position - Vector3.right * speed * Time.deltaTime);
            if (Vector3.Distance(startPosition, transform.position) <= 0.1f)
            {
                isMovingForward = true;
            }
        }
    }
}
