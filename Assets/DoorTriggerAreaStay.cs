using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerAreaStay : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        DoorEvents.current.DoorTriggerEnter(id);
    }
    /*private void OnTriggerExit(Collider other)
    {
        DoorEvents.current.DoorTriggerExit(id);
    }*/
}