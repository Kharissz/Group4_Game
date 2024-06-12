using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy instance;
    void Start()
    {
        // GameObject[] objs = GameObject.FindGameObjectsWithTag("UI");

        // if (objs.Length > 1)
        // {
        //     Destroy(this.gameObject);
        // }

        // DontDestroyOnLoad(this.gameObject);

        for(int i = 0; i < Object.FindObjectsOfType<DontDestroy>().Length; i ++)
        {
            if(Object.FindObjectsOfType<DontDestroy>()[i] != this)
            {
                if(Object.FindObjectsOfType<DontDestroy>()[i].name == gameObject.name)
                {Destroy(gameObject);}
            }
        }
        DontDestroyOnLoad(gameObject);
    }
}
