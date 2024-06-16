using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private RemoteAktif aktif;
    private RemoteNonAktif nonaktif;

    void Start()
    {
        if(gameObject.GetComponent<RemoteAktif>()!=null)
        {aktif = GetComponent<RemoteAktif>();}
        else
        {aktif = null;} 

        if(gameObject.GetComponent<RemoteNonAktif>()!=null)
        {nonaktif = GetComponent<RemoteNonAktif>();}
        else
        {nonaktif = null;}
    }

    public void Picu()
    {
        if(aktif!=null)
        {aktif.Aktif();}
        if(nonaktif!=null)
        {nonaktif.NonAktif();}
    }
}
