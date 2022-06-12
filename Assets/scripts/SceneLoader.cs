using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private string sceneName;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        sceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if(sceneName == "Level1")
        {
            if(score >= 6)
            {
                SceneManager.LoadScene("Level2");
            }
        }
    }
}
