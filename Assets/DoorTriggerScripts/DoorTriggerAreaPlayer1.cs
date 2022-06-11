using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerAreaPlayer1 : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            DoorEvents.current.DoorTriggerEnter(id);
        }
    }
    
}
