using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorTriggerAreaStay : MonoBehaviour
{
    public int id;

    public OpenDoor openDoor;

    private void OnTriggerEnter(Collider other)
    {
        openDoor.current = 0;
        DoorEvents.current.DoorTriggerEnter(id);
    }
    private void OnTriggerExit(Collider other)
    {
        openDoor.current = 1;
        openDoor.move = true;
        DoorEvents.current.DoorTriggerExit(id);
    }
}