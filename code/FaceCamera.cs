using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public string playerTag = "Player"; // Set the player tag in the Inspector
    public float turnSpeed = 5f; // The speed at which the target rotates towards the camera

    private Transform playerTransform;
    private Transform mainCameraTransform;

    void Start()
    {
        // Find the player and main camera by tag
        playerTransform = GameObject.FindGameObjectWithTag(playerTag).transform;
        mainCameraTransform = Camera.main.transform;
    }

    void Update()
    {
        if (playerTransform == null || mainCameraTransform == null)
        {
            Debug.LogWarning("Player or main camera not found. Make sure you set the correct player tag and have a main camera with a 'Camera' tag.");
            return;
        }

        // Calculate the direction from the target to the camera
        Vector3 targetToCamera = mainCameraTransform.position - transform.position;

        // Calculate the rotation that the target should have to face the camera
        Quaternion targetRotation = Quaternion.LookRotation(targetToCamera);

        // Lock the rotation around the z-axis and apply the modified rotation
        Vector3 currentAngles = targetRotation.eulerAngles;
        currentAngles.z = 0f;
        transform.rotation = Quaternion.Euler(currentAngles);

        // Smoothly rotate towards the target rotation around the x and y axis
        Quaternion targetRotationXY = Quaternion.Euler(0f, targetRotation.eulerAngles.y, targetRotation.eulerAngles.x);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationXY, turnSpeed * Time.deltaTime);
    }
}
