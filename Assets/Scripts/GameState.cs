
// Enum representing possible game states
public enum State
{
    Running,  // The game is actively running
    Pause,    // The game is paused
    Finish,   // The game has ended
    Victory   // The game is won
}

// Class to manage the current game state
public class GameState
{
    // Property to store the current state of the game
    public State currentState { get; private set; }

    // Default constructor
    public GameState()
    {
    }

    // Constructor to initialize the game state with a specific state
    public GameState(State state)
    {
        this.currentState = state;
    }

    // Method to change the current game state
    public void ChangeState(State state)
    {
        this.currentState = state;
    }
}
