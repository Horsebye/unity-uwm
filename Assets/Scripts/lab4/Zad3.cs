using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    //https://docs.unity3d.com/ScriptReference/Vector3.SmoothDamp.html

    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5, -10));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}