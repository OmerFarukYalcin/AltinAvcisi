using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeAnimation : MonoBehaviour
{
    float sayac = 2f;

    void Update()
    {
        sayac -= Time.deltaTime;
        if (sayac < 0)
        {
            GetComponent<Animation>().Play();
            sayac = 2f;
        }
        
    }
}
