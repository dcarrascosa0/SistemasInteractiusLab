using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryZone : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public PlayerController controller;
    public ObjectManager objectManager;
    public Vector2 rowsColumns;
    int numObstacles;
    public Tapador tapadorPrefab;
    Vector3 sizes;
    Vector3 bounds;
    public float value;
    public Transform tapadores;
    SceneLoader sceneLoader;
    float lastUpdate;
    void Start()
    {
        sceneLoader = transform.parent.Find("SceneLoader").GetComponent<SceneLoader>();
        tapadores = transform.parent.Find("Tapadores");
    }

    // Update is called once per frame
    void Update()
    {
        lastUpdate += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "obstacle")
        {
            if (lastUpdate > 1.0f)
            {
                if (!collision.transform.GetComponent<Obstacle>().isBig)
                {
                    collision.gameObject.transform.position = new Vector3(Random.Range(17, 90), collision.gameObject.transform.position.y, Random.Range(8, 83));
                    controller.time = 0.0f;
                    collision.transform.GetComponent<Obstacle>().isCatched = false;
                    collision.transform.GetComponent<Obstacle>().controller.hasCatched = false;
                    controller.seconds = 0;


                    for (int i = 0; i < tapadores.childCount; i++)
                    {
                        if (tapadores.GetChild(i).GetComponent<Tapador>().id == collision.gameObject.GetComponent<Obstacle>().id)
                            tapadores.GetChild(i).gameObject.SetActive(false);
                    }

                    collision.gameObject.SetActive(false);
                    sceneLoader.score += 1;

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




                    for (int i = 0; i < tapadores.childCount; i++)
                    {
                        if (tapadores.GetChild(i).GetComponent<Tapador>().id == collision.transform.parent.GetChild(0).GetComponent<Obstacle>().id || tapadores.GetChild(i).GetComponent<Tapador>().id == collision.transform.parent.GetChild(1).GetComponent<Obstacle>().id)
                            tapadores.GetChild(i).gameObject.SetActive(false);
                    }

                    collision.transform.parent.GetChild(0).gameObject.SetActive(false);
                    collision.transform.parent.GetChild(1).gameObject.SetActive(false);
                    sceneLoader.score += 2;

                }
                lastUpdate = 0;
            }
        }
    }
}
