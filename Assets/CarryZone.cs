using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryZone : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public PlayerController controller;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "obstacle")
        {
            collision.gameObject.transform.position = new Vector3(Random.Range(17, 90), collision.gameObject.transform.position.y, Random.Range(8, 83));
            controller.time = 0.0f;
            controller.isCatched = false;
            controller.seconds = 0;
            
        }
    }
}
