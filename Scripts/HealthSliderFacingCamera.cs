using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSliderFacingCamera : MonoBehaviour
{
    private Transform mainCamera;

    private void Start()
    {
        mainCamera = Camera.main.transform;
    }

    private void LateUpdate()
    {
        // Rotate the slider's transform to face the camera
        transform.LookAt(transform.position + mainCamera.rotation * Vector3.forward,
            mainCamera.rotation * Vector3.up);
    }
}
