using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveRemote : MonoBehaviour
{
    [SerializeField] private GameObject objek;

    public void Aktif()
    {
        objek.SetActive(true);
    }

    public void NonAktif()
    {
        objek.SetActive(false);
    }
}
