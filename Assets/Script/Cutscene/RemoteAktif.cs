using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteAktif : MonoBehaviour
{
    [SerializeField] private GameObject objek;

    public void Aktif()
    {
        objek.SetActive(true);
    }

}
