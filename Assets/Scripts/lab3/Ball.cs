using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovePlayer : MonoBehaviour
{
    public float speed = 2.0f;
    Rigidbody rb;
    private bool isRotating = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isRotating && Random.value < 0.75f)
        {
            StartCoroutine(Rotate360());
        }
    }
    void FixedUpdate()
    {
        // pobranie wartoœci zmiany pozycji w danej osi
        // wartoœci s¹ z zakresu [-1, 1]
        float mH = Input.GetAxis("Horizontal");
        float mV = Input.GetAxis("Vertical");

        // tworzymy wektor prêdkoœci
        Vector3 velocity = new Vector3(mH, 0, mV);
        velocity = velocity.normalized * speed * Time.deltaTime;
        // wykonujemy przesuniêcie Rigidbody z uwzglêdnieniem si³ fizycznych
        rb.MovePosition(transform.position + velocity);
    }

    IEnumerator Rotate360()
    {
        isRotating = true;
        float duration = 0.5f; // duration of the rotation
        float elapsed = 0f;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, 360, 0);

        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation;
        isRotating = false;
    }
}