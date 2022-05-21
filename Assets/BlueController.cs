using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool keyPressed;
    private Material startingMaterial;
    public float time;
    private int maxtime;
    public int seconds;
    public List<Obstacle> obstacles;
    private Obstacle currentObstacle;
    private bool isCatching;


    void Start()
    {
        this.obstacles = this.transform.parent.Find("ObjectsManager").GetComponent<ObjectManager>().obstacles;
        this.isCatching = false;
        this.currentObstacle = null;
        this.time = 0.0f;
        this.maxtime = 3;
        try
        {
            this.startingMaterial = this.obstacles[0].transform.GetComponent<Renderer>().material;
        }
        catch { }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Obstacle obstacle in obstacles)
        {
            if (obstacle.isAbove)
            {
                this.time += Time.deltaTime;
                this.seconds = (int)time % 60;
                if (this.seconds >= this.maxtime)
                {
                    obstacle.isCatched = true;
                    this.isCatching = true;
                }

            }
        }
        if (isPositioned())
        {
            currentObstacle.setMaterial(null);
            currentObstacle.isAbove = true;

        }
        else
        {
            currentObstacle = null;
            time = 0.0f;
            foreach (Obstacle obstacle in obstacles)
            {
                obstacle.transform.GetComponent<MeshRenderer>().material = startingMaterial;
                obstacle.isAbove = false;

            }


        }





        foreach (Obstacle obstacle in obstacles)
        {
            if (obstacle.isBig)
            {
                Transform parent = obstacle.transform.parent;
                int count = 0;
                for (int i = 0; i < parent.childCount; i++)
                {
                    if (parent.GetChild(i).GetComponent<Obstacle>().isCatched)
                    {
                        parent.GetChild(i).GetComponent<MeshRenderer>().material = transform.Find("Cube").GetComponent<Renderer>().material;
                        count++;
                    }
                }
                if (count == 2)
                {
                    parent.transform.position = new Vector3(transform.position.x, parent.transform.position.y, transform.position.z);

                }

            }
            else
            {
                if (obstacle.isCatched)
                {
                    obstacle.GetComponent<MeshRenderer>().material = transform.Find("Cube").GetComponent<Renderer>().material;
                    obstacle.transform.position = new Vector3(transform.position.x, obstacle.transform.position.y, transform.position.z);

                }
            }

        }

    }

    bool isPositioned()
    {
        bool isPositioned = false;

        foreach (Obstacle obstacle in obstacles)
        {
            bool xPos = (transform.position.x <= (obstacle.transform.position.x + (obstacle.transform.localScale.x / 2))) && (transform.position.x >= (obstacle.transform.position.x - (obstacle.transform.localScale.x / 2)));
            bool zPos = (transform.position.z <= (obstacle.transform.position.z + (obstacle.transform.localScale.z / 2))) && (transform.position.z >= (obstacle.transform.position.z - (obstacle.transform.localScale.z / 2)));
            if (xPos && zPos)
            {
                isPositioned = true;
                currentObstacle = obstacle;
            }

        }

        return isPositioned;
    }
}

