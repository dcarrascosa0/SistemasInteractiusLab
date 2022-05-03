using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject square;
    private bool isAbove;
    public bool isCatched;
    private bool keyPressed;
    private Material startingMaterial;
    public float time;
    private int maxtime;
    public int seconds;
    void Start()
    {
        time = 0.0f;
        maxtime = 3;
        isCatched = false;
        isAbove = false;
        startingMaterial = square.transform.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isAbove)
        {
            time += Time.deltaTime;
            seconds = (int)time % 60;
            if (seconds >= maxtime)
            {
                isCatched = true;
            }
            
        }
        
        if(isPositioned()) 
        {
            square.GetComponent<MeshRenderer>().material = null;
            isAbove = true;
            
        }
        else
        {
            time = 0.0f;
            square.transform.GetComponent<MeshRenderer>().material = startingMaterial;
            isAbove = false;

        }
        if (isCatched)
        {
            square.GetComponent<MeshRenderer>().material = transform.Find("Cube").GetComponent<Renderer>().material;
            square.transform.position = new Vector3(transform.position.x, square.transform.position.y, transform.position.z);

        }
    }

    bool isPositioned()
    {
        
        bool isPositioned = true;
        if(!((transform.position.x<=(square.transform.position.x + (square.transform.localScale.x/2)))&& (transform.position.x >= (square.transform.position.x - (square.transform.localScale.x / 2)))))
        {
            isPositioned = false;
        }
        if (!((transform.position.z <= (square.transform.position.z + (square.transform.localScale.z / 2))) && (transform.position.z >= (square.transform.position.z - (square.transform.localScale.z / 2)))))
        {
            isPositioned = false;
        }
        return isPositioned;
    }
}
