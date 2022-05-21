using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obstacle;
    public GameObject bigObstacle;
    public int numObstacles;
    public List<Obstacle> obstacles;
    public List<GameObject> bigObstacles;
    public int numBigObstacles;
    
    void Start()
    {
        for(int i = 0; i < numObstacles; i++)
        {
            GameObject myObs = Instantiate(obstacle, new Vector3(Random.Range(17, 90), -10.0f, Random.Range(8, 83)), Quaternion.identity,transform.parent.Find("Obstacles"));
            obstacles.Add(myObs.GetComponent<Obstacle>());
        }

        for (int i = 0; i < numBigObstacles; i++)
        {
            GameObject myObs = Instantiate(bigObstacle, new Vector3(Random.Range(17, 90), -10.0f, Random.Range(8, 83)), Quaternion.identity, transform.parent.Find("Obstacles"));
            for(int j=0;j < myObs.transform.childCount; j++)
            {
                obstacles.Add(myObs.transform.GetChild(j).gameObject.GetComponent<Obstacle>());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
