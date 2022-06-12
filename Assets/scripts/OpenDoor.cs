using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OpenDoor : MonoBehaviour
{
    public GameObject[] waypoints;
    public int id;

    public int current = 0;
    float rotSpeed;
    public float speed;

    public bool move = false;

    private void Start()
    {
        DoorEvents.current.onDoorTriggerEnter += OnTriggerMove;
        //DoorEvents.current.onDoorTriggerEnter += OnTriggerExit;
    }


    void Update()
    {
        if (move == true)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);

            if (Vector3.Distance(waypoints[current].transform.position, transform.position) == 0)
            {
                current++;
                move = false;
                if (current >= waypoints.Length)
                {
                    current = 0;
                }
            }

        }
    
    }

    void OnTriggerMove(int id)
    {
        if (id == this.id)
        {
            move = true; 
        }
    }
    /*void OnTriggerExit(int id)
    {
        move = true;
    }*/

    private void OnDestroy()
    {
        //DoorEvents.current.onDoorTriggerEnter -= OnTriggerMove;
        //DoorEvents.current.onDoorTriggerEnter -= OnTriggerExit;
    }

}
