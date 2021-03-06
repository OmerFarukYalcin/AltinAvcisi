using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyuncuKontrol : MonoBehaviour
{
    private float zaman = 30;
    public AudioClip altin, dusme;
    private float h?z = 10f;
    public UnityEngine.UI.Text zamanText;
    public OyunKontrol oyunK;
    public bool durdur = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (oyunK.oyunAktif && oyunK.altinSay<4 )
        {
            zaman -= Time.deltaTime;
            zamanText.text = "S?re:" + (int)zaman;

            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            x *= Time.deltaTime * h?z;
            y *= Time.deltaTime * h?z;

            transform.Translate(x, 0f, y);
        }
        else if (oyunK.altinSay==4)
        {
            oyunK.kazandin();
        }
        if (oyunK.oyunbitmedi && Input.GetKeyDown(KeyCode.Space))
        {
            enabled = false;
            SceneManager.LoadScene("Bolum1");
        }
        if(zaman <= 0)
        {
            oyunK.oyunAktif = false;
            oyunK.sonText.text = "Maalesef s?reniz bitti kaybettiniz.Tekrar oynamak i?in space tu?una bas?n";
            oyunK.oyunbitmedi = true;
        }
    }

    private void OnCollisionEnter(Collision cls)
    {
        if (cls.gameObject.tag.Equals("altin")) {
            GetComponent<AudioSource>().PlayOneShot(altin, 1f);
            oyunK.altinArttir();
            Destroy(cls.gameObject);
        }
        else if (cls.gameObject.tag.Equals("dusman"))
        {
            GetComponent<AudioSource>().PlayOneShot(dusme, 1f);
            oyunK.oyunAktif = false;
            oyunK.elendin();
            
        }
    }

}
