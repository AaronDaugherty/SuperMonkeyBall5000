using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class CamControl : MonoBehaviour { 

    public GameObject player;
    public float desiredDistance = 10;

    public float dragSpeed = 2;
    private Vector3 dragOrigin;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        desiredDistance += Input.GetAxis("Mouse ScrollWheel");

        Vector3 playerPos = player.transform.position;
        playerPos.y = 0;
        Vector3 cameraPos = transform.position;
        cameraPos.y = 0;
        float curr_distance = (playerPos - cameraPos).magnitude;

        Vector3 delta = 0.1f * (curr_distance - desiredDistance) * (playerPos - cameraPos);
        delta.y = 0;
        transform.LookAt(player.transform.position);

        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);

            transform.Translate(move, Space.World);
        }
        else
        {
            transform.position += delta;
        }

       

    }
}
