using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject Vcam;

    void OnTriggerEnter2D (Collider2D coll)
    {
        if(coll.CompareTag("Player") && !coll.isTrigger)
        {Vcam.SetActive(true);}
    }

    void OnTriggerExit2D (Collider2D coll)
    {
        if(coll.CompareTag("Player") && !coll.isTrigger)
        {Vcam.SetActive(false);}
    }
}
