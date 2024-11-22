using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearAnimation : MonoBehaviour
{

    float timer;

    private void Awake()
    {
        timer = Random.Range(1, 4);
    }

    void Update()
    {
        if (GameControl.instance.GameIsRunning())
        {
            timer -= Time.deltaTime;
            if (timer < 0 && this.gameObject.GetComponent<Animation>().enabled)
            {
                GetComponent<Animation>().Play();
                timer = Random.Range(1, 4);
            }

        }
    }
}
