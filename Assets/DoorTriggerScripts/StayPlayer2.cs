using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayPlayer2 : MonoBehaviour
{
    public int id;

    public OpenDoor openDoor;

    private void OnTriggerEnter(Collider other)
    {
        openDoor.current = 0;
        if (other.CompareTag("Player2"))
        {
            DoorEvents.current.DoorTriggerEnter(id);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player2"))
        {
            openDoor.current = 1;
            openDoor.move = true;
            DoorEvents.current.DoorTriggerExit(id);
        }
    }
}
