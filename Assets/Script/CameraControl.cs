using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //Script
    [SerializeField] GameControl gControl;
    //numeric
    float sensibility = 5f;
    float softness = 2f;
    //Vectors
    Vector2 transformPos;
    Vector2 camPos;
    //GameObject
    GameObject Player;

    void Start()
    {
        Player = transform.parent.gameObject;
        camPos.y = 12f;
    }

    void Update()
    {
        if (gControl.gameRunning && gControl.countGold < 4)
        {
            Vector2 mousePos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            mousePos = Vector2.Scale(mousePos, new Vector2(sensibility * softness, sensibility * softness));
            transformPos.x = Mathf.Lerp(transformPos.x, mousePos.x, 1f / softness);
            transformPos.y = Mathf.Lerp(transformPos.y, mousePos.y, 1f / softness);
            camPos += mousePos;

            transform.localRotation = Quaternion.AngleAxis(-camPos.y, Vector3.right);
            Player.transform.localRotation = Quaternion.AngleAxis(camPos.x, Player.transform.up);
        }
    }
}
