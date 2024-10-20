using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad3 : MonoBehaviour
{
    public float speed = 25.0f;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private float moveDuration = 1f;
    private float moveTimer = 0f;
    private float rotateDuration = 1f;
    private float rotateTimer = 0f;
    private int state = 0;

    void Start()
    {
        startPosition = transform.position;
        SetNextTarget();
    }

    void Update()
    {
        if (state % 2 == 0)
        {
            moveTimer += Time.deltaTime;
            float moveProgress = moveTimer / moveDuration;
            transform.position = Vector3.Lerp(startPosition, targetPosition, moveProgress);

            if (moveProgress >= 1f)
            {
                moveTimer = 0f;
                startPosition = transform.position;
                state++;
                SetNextTarget();
            }
        }
        else
        {
            rotateTimer += Time.deltaTime;
            float rotateProgress = rotateTimer / rotateDuration;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateProgress);

            if (rotateProgress >= 1f)
            {
                rotateTimer = 0f;
                state++;
                SetNextTarget();
            }
        }
    }

    void SetNextTarget()
    {
        switch (state)
        {
            case 0:
                targetPosition = startPosition + transform.forward * 10;
                break;
            case 1:
                targetRotation = transform.rotation * Quaternion.Euler(0, 90, 0);
                break;
            case 2:
                targetPosition = startPosition - transform.forward * 10;
                break;
            case 3:
                targetRotation = transform.rotation * Quaternion.Euler(0, 90, 0);
                break;
            case 4:
                targetPosition = startPosition + transform.forward * 10;
                break;
            case 5:
                targetRotation = transform.rotation * Quaternion.Euler(0, 90, 0);
                break;
            case 6:
                targetPosition = startPosition - transform.forward * 10;
                break;
            case 7:
                targetRotation = transform.rotation * Quaternion.Euler(0, 90, 0);
                break;
            default:
                state = 0;
                SetNextTarget();
                break;
        }
    }
}
