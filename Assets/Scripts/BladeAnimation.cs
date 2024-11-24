
using UnityEngine;

public class BladeAnimation : MonoBehaviour
{
    // Timer to control the interval between blade animations
    private float timer = 2f;

    // Update is called once per frame
    void Update()
    {
        // Ensure the animation only plays when the game is running
        if (GameControl.instance.GameIsRunning())
        {
            // Decrease the timer over time
            timer -= Time.deltaTime;

            // If timer reaches zero, play the blade animation
            if (timer < 0 && this.gameObject.GetComponent<Animation>().enabled)
            {
                GetComponent<Animation>().Play();
                // Reset the timer to its default value
                timer = 2f;
            }
        }
    }
}
