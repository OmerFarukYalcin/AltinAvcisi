using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Sensitivity for camera movement
    private float sensibility = 5f;

    // Smoothness factor for camera transitions
    private float softness = 2f;

    // Position values for transforming the camera
    private Vector2 transformPos;

    // Current position of the camera
    private Vector2 camPos;

    // Reference to the player object
    private GameObject Player;

    void Start()
    {
        // Get the player object from the parent transform
        Player = transform.parent.gameObject;

        // Initialize the camera's vertical position
        camPos.y = 12f;
    }

    void Update()
    {
        // Process camera movement only if the game is running
        if (GameControl.instance.GameIsRunning())
        {
            // Capture mouse input for camera movement
            Vector2 mousePos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            // Scale mouse input by sensitivity and smoothness
            mousePos = Vector2.Scale(mousePos, new Vector2(sensibility * softness, sensibility * softness));

            // Smoothly interpolate the camera's transformation position
            transformPos.x = Mathf.Lerp(transformPos.x, mousePos.x, 1f / softness);
            transformPos.y = Mathf.Lerp(transformPos.y, mousePos.y, 1f / softness);

            // Update the camera position based on mouse input
            camPos += mousePos;

            // Apply rotation to the camera based on the vertical position
            transform.localRotation = Quaternion.AngleAxis(-camPos.y, Vector3.right);

            // Rotate the player object horizontally based on the camera's horizontal position
            Player.transform.localRotation = Quaternion.AngleAxis(camPos.x, Player.transform.up);
        }
    }
}
