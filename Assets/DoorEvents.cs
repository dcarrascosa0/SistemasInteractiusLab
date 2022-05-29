using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class DoorEvents : MonoBehaviour
{
    public static DoorEvents current;

    private void Awake()
    {
            current = this;
    }

    public event Action<int> onDoorTriggerEnter;
    public void DoorTriggerEnter(int id)
    {
        if (onDoorTriggerEnter != null)
        {
            onDoorTriggerEnter(id);
        }
    }
    /*public event Action<int> onDoorTriggerExit;
    public void DoorTriggerExit(int id)
    {
        if (onDoorTriggerExit != null)
        {
            onDoorTriggerExit(id);
        }
    }*/
}
