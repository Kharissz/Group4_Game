using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Dialogue player;
    public Dialogue npcc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            print("Menyentuh NPC");
            npcc.StartDialogue();
        }
    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            print("Keluar dari jangkauan NPC");
            npcc.EndDialogue();
        }
    }
}
