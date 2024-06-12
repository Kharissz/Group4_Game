using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    private GameObject pos;
    private bool pindah;
    // void Awake()
    // {
    //     pos = GameObject.FindWithTag("Spawn");
    //     transform.position = pos.transform.position;
    //     Debug.Log(pos + "ADA!!!");
    // }

    private void Start()
    {
        // Make sure the listener isn't added twice
        SceneManager.sceneLoaded -= OnSceneLoaded;
        // Whenever a scene is loaded, call OnSceneLoaded
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Find the object in Scene1
        pos = GameObject.Find("GameObjectInScene1");

        // Load Scene2
        SceneManager.LoadScene("Test");
    }

    private void OnDestroy()
    {
        // Always clean up listeners when not needed anymore
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Test")
        {
            // Find the object in Scene2
            pos = GameObject.Find("Spawn");
            transform.position = pos.transform.position;
        }
    }
}
