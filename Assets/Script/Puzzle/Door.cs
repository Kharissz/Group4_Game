using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{
    [SerializeField] string requireKey;
    public Dialogue dial;
    bool isOpen = false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player") && !isOpen)
        {
            if(Keyholder.Instance.IsKeyCollected(requireKey))
            {
                OpenDoor();
            }
        }
        else
        {
            dial.StartDialogue();
        }
    }

    void OpenDoor()
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
