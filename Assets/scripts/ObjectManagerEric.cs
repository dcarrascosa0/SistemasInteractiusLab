using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ObjectManagerEric : MonoBehaviour
{
    // Start is called before the first frame update
    public string artPath;
    public Material[] artPices;
    public int numArtPices;

    public int numObstacles;
    public int numBigObstacles;

    public GameObject obstacle;
    public GameObject bigObstacle;

    public List<Obstacle> obstacles;
    public List<GameObject> bigObstacles;

    void Start()
    {
        //artPices = GetAtPath(artPath);
        //numArtPices = artPices.Count - 1; // last material is the complete piece of Art
        

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

    public static void GetAtPath<T> (string path) {

        ArrayList al = new ArrayList();
        string [] fileEntries = Directory.GetFiles(Application.dataPath + "/" + path);
        Debug.Log("Application.dataPath");
        /*foreach(string fileName in fileEntries)
        {
            int index = fileName.LastIndexOf("/");
            string localPath = "Assets/" + path;

            if (index > 0)
                localPath += fileName.Substring(index);

            Object t = UnityEditor.AssetDatabase.LoadAssetAtPath(localPath, typeof(T));
 
            if(t != null)
                al.Add(t);
        }
        T[] result = new T[al.Count];
        for(int i=0;i<al.Count;i++)
            result[i] = (T)al[i];
        */


    }
}
