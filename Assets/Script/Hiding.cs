using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject interactButton;
    private Animator animPlayer;
    private Rigidbody2D rigidPlayer;
    private CapsuleCollider2D collPlayer;
    private Transform capsule;
    private GameObject cap;
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

        cap = GameObject.Find("isTrigger");

        Debug.Log(cap);
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
        if(Input.GetKeyDown("e") && (hide||!isHiding) &&  i==1)
        { 
            isHiding = true;
            animPlayer.SetBool("Hiding", isHiding);
            rigidPlayer.constraints = RigidbodyConstraints2D.FreezeAll;
            collPlayer.enabled = false;
            // cap.SetActive(false);
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
            // cap.SetActive(true);

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