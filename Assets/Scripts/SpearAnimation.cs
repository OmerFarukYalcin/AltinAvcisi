
using UnityEngine;

public class SpearAnimation : MonoBehaviour
{
    // Timer to control the interval between spear animations
    private float timer;

    private void Awake()
    {
        // Initialize the timer with a random value between 1 and 4 seconds
        timer = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        // Ensure the animation only plays when the game is running
        if (GameControl.instance.GameIsRunning())
        {
            // Decrease the timer over time
            timer -= Time.deltaTime;

            // If timer reaches zero, play the spear animation
            if (timer < 0 && this.gameObject.GetComponent<Animation>().enabled)
            {
                GetComponent<Animation>().Play();
                // Reset the timer with a new random value
                timer = Random.Range(1, 4);
            }
        }
    }
}
