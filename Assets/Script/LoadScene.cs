using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadNextScene()
    {
        // Assuming scenes are in a build order
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if the next scene index is not out of range
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
            // Berhenti menyalakan BGM ketika pindah scene
            // AudioManager.Instance.musicSource.Stop();
        }
        else
        {
            Debug.Log("No more scenes to load.");
        }
    }

    void OnEnable()
    {
        LoadNextScene();

    }

}
