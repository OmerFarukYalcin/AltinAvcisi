using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeAnimation : MonoBehaviour
{
    float timer = 2f;

    void Update()
    {
        if (GameControl.instance.GameIsRunning())
        {
            timer -= Time.deltaTime;
            if (timer < 0 && this.gameObject.GetComponent<Animation>().enabled)
            {
                GetComponent<Animation>().Play();
                timer = 2f;
            }
        }
    }
}
