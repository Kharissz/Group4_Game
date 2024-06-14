using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public bool detect = false;
    [SerializeField] private Hantu hantu;
    public float speedUp;

    private int i=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(detect && i==0)
        {
            hantu.kecepatan += speedUp;
            Counter();
        }        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            detect = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            detect = false;
            i=0;
            hantu.kecepatan = hantu.kecepatanAwal;
        }
    }

    void Counter()
    {
        if(i==0) i=1;

    }
}
