using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    
    public static Position instance;
    public Vector3 playerSpawnPosition; // Posisi pemain saat memasuki scene baru melalui pintu
    public Vector3 previousPos;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Biarkan GameManager tetap ada di antara scene yang dimuat
        }
        else
        {
            Destroy(gameObject); // Hancurkan duplikat GameManager jika ada lebih dari satu
        }

    }

    void Update()
    {
        // enter = false;
        // if(enter == true)
        // {
        //     previousPos = playerSpawnPosition;
        //     test();
        // }
    }

    void test()
    {
        Respawn.instance.transform.position = previousPos;
    }
}
