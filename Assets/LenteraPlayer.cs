using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LenteraPlayer : MonoBehaviour
{
    private float move;
    [SerializeField] private Movement gerak;
    [SerializeField] private GameObject lenteraIdle;
    [SerializeField] private GameObject lenteraWalkKanan;
    [SerializeField] private GameObject lenteraWalkKiri;

    void Start()
    {
    }

    void Update()
    {
        move = gerak.horizontalMove;        
        if(move > 0)
        {
            lenteraWalkKanan.SetActive(true);
            lenteraWalkKiri.SetActive(false);
            lenteraIdle.SetActive(false);
        }
        else if(move<0)
        {
            lenteraWalkKiri.SetActive(true);
            lenteraWalkKanan.SetActive(false);
            lenteraIdle.SetActive(false);


        }
        else
        {
            lenteraIdle.SetActive(true);
            lenteraWalkKanan.SetActive(false);
            lenteraWalkKiri.SetActive(false);

        }
    }
}
