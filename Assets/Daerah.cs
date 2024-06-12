using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Daerah : MonoBehaviour
{
    [SerializeField] private CinemachineConfiner2D cam;
    private GameObject domain;
    // public GameObject[] domains;
    // public GameObject[] gates;
    
    void Start()
    {
        cam = GetComponent<CinemachineConfiner2D>();
        // domains = GameObject.FindGameObjectsWithTag("domain");
        // gates = GameObject.FindGameObjectsWithTag("gate");
    }

    void Update()
    {

    }

    public void ChangeCam(GameObject obj)
    {
        cam.m_BoundingShape2D = obj.GetComponent<PolygonCollider2D>();
    }
}
