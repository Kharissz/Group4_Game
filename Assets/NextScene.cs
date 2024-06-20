using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] private GameObject button;
    private bool enter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e") && enter)
        {
            Next();
        }        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            button.SetActive(true);
            enter = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            button.SetActive(false);
            enter = true;
        }
    }

    public void Next()
    {
        // Assuming scenes are in a build order
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        Debug.Log(SceneManager.sceneCountInBuildSettings);

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
