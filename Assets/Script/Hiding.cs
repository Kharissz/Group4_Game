using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    private Transform capsule;
    private GameObject player;
    private Animator animPlayer;
    private Rigidbody2D rigidPlayer;
    private CapsuleCollider2D collPlayer;
    [SerializeField] private GameObject interactButton;
    [SerializeField] GameObject lamp;
    public GameObject[] ghosts;
    public GameObject[] sensors;
    private int i = 1;

    bool hide = false;
    public bool isHiding = false;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animPlayer = player.GetComponent<Animator>();
        rigidPlayer = player.GetComponent<Rigidbody2D>();
        capsule = transform.Find("isTrigger");
        collPlayer = capsule.GetComponent<CapsuleCollider2D>();
        ghosts = GameObject.FindGameObjectsWithTag("hantu");
        sensors = GameObject.FindGameObjectsWithTag("sensor");

    }

    void Update()
    {
        if(Input.GetKeyDown("e") && i == 1)
        {Hide();}
        else if(Input.GetKeyDown("e") && i == 2)
        {UnHide();}
    }

    void Hide()
    {
        if(Input.GetKeyDown("e") && hide && !isHiding &&  i==1)
        { 
            isHiding = true;
            animPlayer.SetBool("Hiding", isHiding);
            rigidPlayer.constraints = RigidbodyConstraints2D.FreezeAll;
            collPlayer.enabled = false;
            lamp.SetActive(false);

            foreach(GameObject ghost in ghosts)
            {
                BoxCollider2D coll = ghost.GetComponent<BoxCollider2D>();
                coll.enabled=false;
            }
            foreach(GameObject sensor in sensors)
            {
                BoxCollider2D sen = sensor.GetComponent<BoxCollider2D>();
                sen.enabled = false;
            }
            
            i++;
        } 
    }

    void UnHide()
    {
        if(i==2 && Input.GetKeyDown("e"))
        {
            isHiding = false;
            animPlayer.SetBool("Hiding", isHiding);
            rigidPlayer.constraints = RigidbodyConstraints2D.FreezeRotation;
            collPlayer.enabled = true;
            lamp.SetActive(true);

            foreach(GameObject ghost in ghosts)
            {
                BoxCollider2D coll = ghost.GetComponent<BoxCollider2D>();
                coll.enabled=true;
            }
            foreach(GameObject sensor in sensors)
            {
                BoxCollider2D sen = sensor.GetComponent<BoxCollider2D>();
                sen.enabled = true;
            }

            i--;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("hide"))
        {
            interactButton.SetActive(true);
            hide = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.CompareTag("hide"))
        {
            interactButton.SetActive(false);
            hide = false;
        }
    }

}
