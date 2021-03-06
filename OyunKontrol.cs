using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    public bool oyunAktif = false;
    public bool oyunbitmedi = false;
    public int altinSay = 0;
    public UnityEngine.UI.Text altinSayText,sonText;
    public UnityEngine.UI.Button btnBasla;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

    }

    public void altinArttir()
    {
        altinSay += 1;
        altinSayText.text = altinSay + "";
    }

    public void oyunBasla()
    {
        oyunAktif = true;
        btnBasla.gameObject.SetActive(false);
    }

    public void elendin()
    {
        sonText.text = "Maalesef engeli a?amad?n kaybettin!Tekrar ba?lamak istiyorsan Space tu?una bas";
        oyunbitmedi = true;
    }
    public void kazandin()
    {
        sonText.text = "Oyunu kazand?n?z.Tebrikler!Tekrar ba?lamak istiyorsan Space tu?una bas";
        if (Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene("Bolum1");
    }

}
