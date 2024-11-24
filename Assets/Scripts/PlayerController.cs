using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement speed of the player
    private float speed = 10f;

    // Audio clips for collecting gold and colliding with enemies
    [SerializeField] private AudioClip goldSound;
    [SerializeField] private AudioClip fallSound;

    // Vector to store the player's movement input
    private Vector3 movementVector;

    // Update is called once per frame
    void Update()
    {
        // Process player movement only if the game is running
        if (GameControl.instance.GameIsRunning())
        {
            // Capture player input for movement
            CaptureMovementInput();

            // Apply the movement to the player's transform
            transform.Translate(CalculateMovementVector(movementVector.x, movementVector.z, speed, Time.deltaTime));
        }
    }

    // Captures input for horizontal and vertical movement
    private void CaptureMovementInput()
    {
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.z = Input.GetAxis("Vertical");
    }

    // Calculates the movement vector based on input and movement speed
    public Vector3 CalculateMovementVector(float horizontal, float vertical, float moveSpeed, float deltaTime)
    {
        float x = horizontal * moveSpeed * deltaTime;
        float z = vertical * moveSpeed * deltaTime;

        return new Vector3(x, 0f, z); // Keep y-axis movement fixed at 0
    }

    // Handles collisions with various game objects
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player collided with a "gold" object
        if (collision.gameObject.CompareTag("altin"))
        {
            // Play the gold collection sound
            GetComponent<AudioSource>().PlayOneShot(goldSound, 1f);

            // Notify the game control to increase the gold count
            GameControl.instance.IncreaseGold();

            // Destroy the collected gold object
            Destroy(collision.gameObject);
        }
        // Check if the player collided with an "enemy" object
        else if (collision.gameObject.CompareTag("dusman"))
        {
            // Play the collision sound for losing
            GetComponent<AudioSource>().PlayOneShot(fallSound, 1f);

            // Notify the game control to change the game state to "Finish"
            GameControl.instance.ChangeGameState(State.Finish);
        }
    }
}
