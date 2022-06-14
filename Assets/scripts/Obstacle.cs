using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool isAbove;
    public bool isCatched;
    public bool isBig;
    public PlayerController controller;
    public Material starterMaterial;
    public Material selectedMaterial;
    private PlayerController aboveController;
    private Transform parent;
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
        aboveController = null;
        if (transform.parent.tag == "BigObstacle")
        {
            isBig = true;
        }
        else
        {
            isBig = false;
        }
        isAbove = false;
        isCatched = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isCatched)
        {
            setMaterial(controller.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material);

            if (!isBig)
            {
                transform.position = new Vector3(controller.transform.position.x, transform.position.y, controller.transform.position.z);
            }
            else
            {
                int counter = 0;
                for(int i = 0; i < parent.childCount; i++)
                {
                    if (parent.GetChild(i).GetComponent<Obstacle>().isCatched)
                        counter++;
                }
                if (counter == 2)
                {
                    Vector3 position1 = parent.GetChild(0).GetComponent<Obstacle>().controller.transform.position;
                    Vector3 position2 = parent.GetChild(1).GetComponent<Obstacle>().controller.transform.position;
                    Vector3 middlePosition = (position1 + position2) / 2.0f;

                    if(Vector3.Distance(position1,position2)<=5)
                        if(Vector2.Distance(new Vector2(middlePosition.x,middlePosition.z), new Vector2(parent.transform.position.x,parent.transform.position.z))<=5)
                        parent.transform.position = new Vector3(middlePosition.x, parent.transform.position.y, middlePosition.z);
                }
            }
           
        }
        
        else if(!isCatched && isAbove)
        {
            if(!aboveController.hasCatched)
                setMaterial(selectedMaterial);
        }
        else
        {
            setMaterial(starterMaterial);
        }
    }

    public void setMaterial(Material mat)
    {
        
        transform.GetComponent<MeshRenderer>().material = mat;
    }

    public void sendIsAbove(bool isItAbove, PlayerController controll)
    {
        if(aboveController == null && isItAbove)
        {
            aboveController = controll;
            isAbove = true;
        }
        if(!isItAbove && aboveController == controll)
        {
            isAbove = false;
            aboveController = null;
        }
    }

    public void setController(PlayerController controll)
    {
        controller = controll;
        isCatched = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "wall")
        {
            Debug.Log("Collison");
            isCatched = false;
            isAbove = false;
            controller.hasCatched = false;
        }

        if(collision.transform.tag == "obstacle" || collision.transform.tag == "bigObstacle")
        {
            Physics.IgnoreCollision(transform.GetComponent<Collider>(), collision.transform.GetComponent<Collider>());
        }
        Vector3 dir = collision.contacts[0].point - transform.position;
        // We then get the opposite (-Vector3) and normalize it
        dir = -dir.normalized;
        // And finally we add force in the direction of dir and multiply it by force. 
        // This will push back the player
        GetComponent<Rigidbody>().AddForce(dir * 3);
    }
}
