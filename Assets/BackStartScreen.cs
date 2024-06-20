using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackStartScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        SceneManager.LoadScene("Start Screen");
    }
}
