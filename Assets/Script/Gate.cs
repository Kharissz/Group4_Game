using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{

    [SerializeField] GameObject tujuan;
    [SerializeField] GameObject daerah;
    public GameObject UIbutton;
    private GameObject player;
    private GameObject vcamera;
    private Daerah domain;
    bool interact;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        vcamera = GameObject.FindGameObjectWithTag("Vcam");

        domain = vcamera.GetComponent<Daerah>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && interact)
        {
            Teleport();
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

    void Teleport()
    {
        player.transform.position = tujuan.transform.position;
        domain.ChangeCam(daerah);
    }
}
