using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class ObjectManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obstacle;
    public GameObject bigObstacle;
    public int numObstacles;
    public List<Obstacle> obstacles;
    public List<GameObject> bigObstacles;
    public int numBigObstacles;
    public Material[] files;
    public string file;
    public int index;
    public Material mat;
    public List<Vector3> positions;
    
    void Start()
    {
        index = 1;
        GetAtPath(file);

        mat = files[0];

        for (int i = 0; i < numObstacles; i++)
        {
            
            GameObject myObs = Instantiate(obstacle, new Vector3(positions[index-1].x, -10.0f, positions[index - 1].z), Quaternion.identity,transform.parent.Find("Obstacles"));
            myObs.GetComponent<Obstacle>().starterMaterial = files[index];
            myObs.GetComponent<Obstacle>().id = int.Parse(files[index].name.Split(' ')[files[index].name.Split(' ').Length-1]);
            obstacles.Add(myObs.GetComponent<Obstacle>());
            index += 1;
        }

        for (int i = 0; i < numBigObstacles; i++)
        {
            GameObject myObs = Instantiate(bigObstacle, new Vector3(positions[index - 1].x, -10.0f, positions[index - 1].z), Quaternion.identity, transform.parent.Find("Obstacles"));
            for(int j=0;j < myObs.transform.childCount; j++)
            {
                myObs.transform.GetChild(j).GetComponent<Obstacle>().starterMaterial = files[index];
                obstacles.Add(myObs.transform.GetChild(j).gameObject.GetComponent<Obstacle>());
                index += 1;
            }
        }
        

        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GetAtPath(string file)
    {

        files = Resources.LoadAll<Material>("ArtMaterials/"+file);
        


    }
}
