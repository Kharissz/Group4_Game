using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject MenuPause;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            MenuPause.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void PauseGame()
    {Time.timeScale = 0f;}

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        MenuPause.SetActive(false);
    }

    public void Setting()
    {
        
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Screen");
    }
}
