using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerAreaPlayer2 : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player2"))
        {
            DoorEvents.current.DoorTriggerEnter(id);
        }
    }
}
