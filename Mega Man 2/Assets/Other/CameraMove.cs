using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    public Camera cam;
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.15f;

    void Start()
    {

        offset = new Vector3(0, 0, -10);

    }
    void LateUpdate()
    {
        Vector3 desiredLocation = transform.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredLocation, smoothSpeed);
        transform.position = smoothPosition;

    }


}
