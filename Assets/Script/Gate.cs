using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    public int SceneBuildIndex;
    bool interact;
    public GameObject UIbutton;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && interact)
        {
            // Position.instance.enter = true;
            // Position.instance.previousPos = Position.instance.playerSpawnPosition;
            SceneManager.LoadScene(SceneBuildIndex, LoadSceneMode.Single);
        }  
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            UIbutton.SetActive(true);
            interact = true;
            // Position.instance.playerSpawnPosition = coll.transform.position;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            UIbutton.SetActive(false);
            interact = false;
        }
    }
}
