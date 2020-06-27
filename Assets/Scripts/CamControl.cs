using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.U2D;

public class CamControl : MonoBehaviour
{

    public float radius = 10;
    public GameObject player;
    public float angle = 30.0f;
    public float stepSize = 0.1f;
    public float panSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        radius -= Input.GetAxis("Mouse ScrollWheel");
        float horizOffset = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        float vertOffset = radius * Mathf.Sin(angle * Mathf.Deg2Rad);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            float h = Input.GetAxis("Mouse X");
            float v = Input.GetAxis("Mouse Y");
            //limits to keep from panning too far up or down
            if (transform.up.y <= 0.1 && transform.position.y > player.transform.position.y)
                v = Mathf.Min(0, v);
            else if (transform.up.y <= 0.1 && transform.position.y < player.transform.position.y)
                v = Mathf.Max(0, v);

            transform.position += (transform.up * v  + transform.right * h) * panSpeed;
        }

        Vector3 playerPos = player.transform.position + Vector3.up * vertOffset; //this is a point a little bit above the player

        Vector3 diff = playerPos - transform.position; //difference between player and camera positions
        transform.position += stepSize * (diff.magnitude - horizOffset) * diff;
        transform.LookAt(player.transform.position);
    }
}

