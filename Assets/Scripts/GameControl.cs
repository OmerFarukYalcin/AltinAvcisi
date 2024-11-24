
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    // Singleton instance of GameControl
    public static GameControl instance;

    // The current state of the game
    private GameState gameState = new();

    // Gold count collected by the player
    public int countGold { get; private set; }

    // UI Text component for displaying the gold count
    [SerializeField] private Text countGoldText;

    // Panel displayed for game transitions (e.g., pause, victory, or game over)
    [SerializeField] private GameObject finalPanel;

    private void Awake()
    {
        // Ensure only one instance of GameControl exists (Singleton pattern)
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        // Initialize the game in a paused state
        ChangeGameState(State.Pause);
    }

    private void Update()
    {
        // Quit the application when the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    // Increment the gold count and update the UI
    public void IncreaseGold()
    {
        countGold++;
        countGoldText.text = countGold.ToString();

        // If the player collects 4 gold pieces, they win the game
        if (countGold == 4)
        {
            ChangeGameState(State.Victory);
        }
    }

    // Start or restart the game
    public void StartGame()
    {
        // If the game is paused, transition to the running state
        if (gameState.currentState == State.Pause)
        {
            ChangeGameState(State.Running);
        }
        // Otherwise, restart the current scene
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Change the current state of the game and update the UI accordingly
    public void ChangeGameState(State state)
    {
        // Update the game state
        gameState.ChangeState(state);

        // Show or hide the final panel based on the game state
        finalPanel.SetActive(gameState.currentState != State.Running);

        // Update panel and button texts based on the game state
        Text panelText = finalPanel.transform.Find("final").GetComponent<Text>();
        Text buttonText = finalPanel.transform.Find("startButton").GetChild(0).GetComponent<Text>();

        // Default button text
        buttonText.text = "Start Game";

        // Handle text updates for each game state
        switch (gameState.currentState)
        {
            case State.Running:
                break;

            case State.Pause:
                panelText.text = "Press start when you are ready to play.";
                break;

            case State.Finish:
                panelText.text = "Unfortunately, you lost the game!";
                buttonText.text = "Play Again";
                break;

            case State.Victory:
                panelText.text = "Congratulations! You won the game!";
                buttonText.text = "Play Again";
                break;
        }
    }

    // Check if the game is currently running
    public bool GameIsRunning()
    {
        return gameState.currentState == State.Running;
    }
}
