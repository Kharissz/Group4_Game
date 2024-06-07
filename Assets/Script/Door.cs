using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] string requireKey;
    bool isOpen = false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player") && !isOpen)
        {
            if(Keyholder.Instance.IsKeyCollected(requireKey))
            {
                OpenDoor();
            }
        }
        else
        {
            Debug.Log("Key " + requireKey + "is require");
        }
    }

    void OpenDoor()
    {
        Debug.Log("Door is Open");        
    }

}
