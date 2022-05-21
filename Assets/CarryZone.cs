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
            if (!collision.transform.GetComponent<Obstacle>().isBig)
            {
                collision.gameObject.transform.position = new Vector3(Random.Range(17, 90), collision.gameObject.transform.position.y, Random.Range(8, 83));
                controller.time = 0.0f;
                collision.transform.GetComponent<Obstacle>().isCatched = false;
                collision.transform.GetComponent<Obstacle>().controller.hasCatched = false;
                controller.seconds = 0;
            }
                
            else
            {
                collision.transform.parent.position = new Vector3(Random.Range(17, 90), collision.transform.parent.gameObject.transform.position.y, Random.Range(8, 83));
                collision.transform.parent.GetChild(0).GetComponent<Obstacle>().controller.time = 0.0f;
                collision.transform.parent.GetChild(0).GetComponent<Obstacle>().isCatched = false;
                collision.transform.parent.GetChild(0).GetComponent<Obstacle>().controller.hasCatched = false;
                collision.transform.parent.GetChild(0).GetComponent<Obstacle>().controller.seconds = 0;
                collision.transform.parent.GetChild(1).GetComponent<Obstacle>().controller.time = 0.0f;
                collision.transform.parent.GetChild(1).GetComponent<Obstacle>().isCatched = false;
                collision.transform.parent.GetChild(1).GetComponent<Obstacle>().controller.hasCatched = false;
                collision.transform.parent.GetChild(1).GetComponent<Obstacle>().controller.seconds = 0;



            }


        }
    }
}
