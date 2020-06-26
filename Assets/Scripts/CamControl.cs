using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour { 

    public GameObject player;
    public float desiredDistance = 10;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float curr_distance = (player.transform.position - transform.position).magnitude;

        transform.position += 0.1f*(curr_distance-desiredDistance) * (player.transform.position - transform.position);
        transform.LookAt(player.transform.position);
        
    }
}
