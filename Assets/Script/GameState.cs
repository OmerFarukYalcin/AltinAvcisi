public enum State
{
    Running,
    Pause,
    Finish,
    Victory,
}
public class GameState
{
    public State state { get; private set; }
    public GameState(State state)
    {
        this.state = state;
    }

    public void ChangeState(State state)
    {
        this.state = state;
    }
}
