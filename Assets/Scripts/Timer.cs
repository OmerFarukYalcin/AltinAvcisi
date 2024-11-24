
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Initial countdown time in seconds
    private float time = 30;

    // Reference to the UI Text component displaying the timer
    [SerializeField] private Text timeText;

    // Update is called once per frame
    void Update()
    {
        // Ensure the timer updates only when the game is running
        if (GameControl.instance.GameIsRunning())
        {
            // Decrease the remaining time
            time -= Time.deltaTime;

            // Update the UI to display the remaining time
            timeText.text = "Time: " + (int)time;
        }

        // If time runs out, transition the game to the "Finish" state
        if (time <= 0)
        {
            GameControl.instance.ChangeGameState(State.Finish);
        }
    }
}
