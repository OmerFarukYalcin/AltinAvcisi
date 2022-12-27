using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAnimationControl : MonoBehaviour
{
    //numeric
    float timer = 2f;
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            GetComponent<Animator>().Play(0);
            timer = Random.Range(4, 6);
        }
    }
}
