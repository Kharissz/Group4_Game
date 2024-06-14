using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stationer : MonoBehaviour
{
    [SerializeField] AIChase aIChase;
    [SerializeField] Transform station;

    void Start()
    {
    }

    void Update()
    {

    }

    public void Stationing()
    {
        // FLIP
        transform.localScale = new Vector3(-1,1,1);
        // Balik ke Tempat
        transform.position = Vector2.MoveTowards(transform.position, station.transform.position, aIChase.speed *Time.deltaTime);
    }
}
