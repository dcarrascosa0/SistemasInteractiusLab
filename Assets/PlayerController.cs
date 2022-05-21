using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool keyPressed;
    public float time;
    private int maxtime;
    public int seconds;
    public List<Obstacle> obstacles;
    public Obstacle currentObstacle;
    private bool isCatching;
    public bool hasCatched;

    
    void Start()
    {
        hasCatched = false;
        this.obstacles = this.transform.parent.Find("ObjectsManager").GetComponent<ObjectManager>().obstacles;
        this.isCatching = false;
        this.currentObstacle = null;
        this.time = 0.0f;
        this.maxtime = 3;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            
        if (isPositioned() && !hasCatched)
        {
            /*foreach(Obstacle obstacle in obstacles)
            {
                if (obstacle != currentObstacle)
                {
                    obstacle.setMaterial(startingMaterial);
                }
            }
            */
            this.time += Time.deltaTime;
            this.seconds = (int)time % 60;
            if (this.seconds >= this.maxtime)
            {
                time = 0;
                seconds = 0;
                currentObstacle.setController(this);
                hasCatched = true;
                this.isCatching = true;
            }
        }
        else
        {
            time = 0;
            seconds = 0;
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
                obstacle.sendIsAbove(true, this);
            }
            else
            {
                obstacle.sendIsAbove(false, this);
            }
           
        }
        return isPositioned;
        
    }
}
