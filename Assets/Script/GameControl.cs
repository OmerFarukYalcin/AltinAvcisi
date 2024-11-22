using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    private GameState gameState;
    public int countGold = 0;
    [SerializeField] Text countGoldText;
    public Text finalText;
    [SerializeField] GameObject finalPanel;

    private void Awake()
    {
        gameState = new(State.Pause);
    }

    void Start()
    {
        GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

    }

    public void IncreaseGold()
    {
        countGold += 1;
        countGoldText.text = countGold + "";
    }

    public void startGame()
    {
        gameState.ChangeState(State.Running);
    }

    public void ChangeGameState(State state)
    {
        gameState.ChangeState(state);

        switch (gameState.state)
        {
            case State.Running:
                break;
            case State.Pause:
                break;
            case State.Finish:
                break;
            case State.Victory:
                break;
        }
    }

    public void Eliminated()
    {
        gameState.ChangeState(State.Finish);
        finalText.text = "Maalesef engeli a�amad�n kaybettin!Tekrar ba�lamak istiyorsan Space tu�una bas";
    }
    private void Victory()
    {
        finalText.text = "Oyunu kazand�n�z.Tebrikler!Tekrar ba�lamak istiyorsan Space tu�una bas";
        if (Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene("Bolum1");
    }

    public bool GameIsRunning()
    {
        return gameState.state == State.Running;
    }
    public bool IsGamePlayable()
    {
        return gameState.state == State.Running && countGold < 4;
    }

}
