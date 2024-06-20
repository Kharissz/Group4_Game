using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Ending : MonoBehaviour
{
    public GameObject Leak;
    private Keyholder restartKey;
    void Start()
    {
        restartKey = GetComponent<Keyholder>();
    }
    void Update()
    {
        if(Leak==null)
        {
            Invoke("Tamat",3f);
        }
    }
    void Tamat()
    {
        restartKey.RestartCollectedKey();
        // Assuming scenes are in a build order
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        // Check if the next scene index is not out of range
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more scenes to load.");
        }
    }
}
