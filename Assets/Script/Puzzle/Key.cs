using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public string keyId;

    private void Start()
    {
        if(Keyholder.Instance.IsKeyCollected(keyId))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            Keyholder.Instance.CollectKey(keyId);
            gameObject.SetActive(false);
        }
    }
}

