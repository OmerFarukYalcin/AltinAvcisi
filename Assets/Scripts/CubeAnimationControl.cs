
using UnityEngine;

public class CubeAnimationControl : MonoBehaviour
{
    // Timer to control animation intervals
    private float timer = 2f;

    // Update is called once per frame
    void Update()
    {
        // Decrease the timer over time
        timer -= Time.deltaTime;

        // If timer reaches zero, play the animation and reset the timer
        if (timer < 0)
        {
            // Play the first animation in the Animator component
            GetComponent<Animator>().Play(0);

            // Reset the timer with a random value between 4 and 6 seconds
            timer = Random.Range(4, 6);
        }
    }
}
