using UnityEngine;

public class TPPCameraFollow : MonoBehaviour
{
    public Transform target; // The object the camera will follow
    public Vector3 offset = new Vector3(0, 2, -5); // Camera offset from the target
    public float smoothSpeed = 0.125f; // Smoothing factor for camera movement
    public float rotationSpeed = 2.0f; // Speed at which the camera follows rotation

    private void LateUpdate()
    {
        // Calculate the desired position based on the target's position and offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move the camera to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Calculate the target rotation based on the target's rotation
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);

        // Smoothly rotate the camera towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
