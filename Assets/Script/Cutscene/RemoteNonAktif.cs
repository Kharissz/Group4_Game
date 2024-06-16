using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteNonAktif : MonoBehaviour
{
    [SerializeField] private GameObject objek;
    public void NonAktif()
    {
        objek.SetActive(false);
    }

    void OnEnable()
    {
        NonAktif();
    }
}
