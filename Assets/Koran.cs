using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Koran : MonoBehaviour
{
    public GameObject UI;
    public TextMeshProUGUI teks;
    [TextAreaAttribute] public string konteks;
    public GameObject interak;
    bool kena;

    void Update()
    {
        if(Input.GetKeyDown("e") && kena)
        {
            UI.SetActive(true);
            Info();
        }
    }

    public void Info()
    {
        teks.text = konteks;
    }

    public void Kembali()
    {
        UI.SetActive(false);
        teks.text = string.Empty;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            interak.SetActive(true);
            kena = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            interak.SetActive(false);
            kena = false;
        }
    }
}
