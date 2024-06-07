using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Screen : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Cutscene 1");   
    }

    public void Quit()
    {
        Application.Quit();
    }
}
