using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SkipLevel : MonoBehaviour
{
    private string sceneName;


    void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void OnTriggerEnter()
    {
        SceneManager.LoadScene("Level2");
    }
}
