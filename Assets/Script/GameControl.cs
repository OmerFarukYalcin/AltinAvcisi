using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    //bool
    public bool gameRunning = false;
    public bool gameFin = false;
    //numeric
    public int countGold = 0;
    //UI
    [SerializeField] Text countGoldText;
    public Text finalText;
    [SerializeField] Button startButton;

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
        gameRunning = true;
        startButton.gameObject.SetActive(false);
    }

    public void Eliminated()
    {
        finalText.text = "Maalesef engeli a�amad�n kaybettin!Tekrar ba�lamak istiyorsan Space tu�una bas";
        gameFin = true;
    }
    public void Victory()
    {
        finalText.text = "Oyunu kazand�n�z.Tebrikler!Tekrar ba�lamak istiyorsan Space tu�una bas";
        if (Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene("Bolum1");
    }

}
