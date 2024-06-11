using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public static Respawn instance;
    Vector3 temp = new Vector3(0,0,0);

    void Awake()
    {
        Debug.Log("Respawnn");
        if(instance!=null) 
        {
            Destroy(gameObject);
        }
        else 
        {
            instance = this;
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");

            if (objs.Length > 1)
            {
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(gameObject);

        }

    }
    void Start()
    {
        Debug.Log("AWAL DARI SCENE");
        if(Position.instance.previousPos == temp)
        {
            transform.position = transform.position;
        } else{
            Res();
        }
    }
    void Res()
    {
        transform.position = Position.instance.previousPos;
    }
}
