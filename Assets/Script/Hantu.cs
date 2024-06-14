using System.Collections;
using System.Collections.Generic;
// using System.Diagnostics;
using UnityEngine;

public class Hantu : MonoBehaviour
{
    public float damage;
    public float kecepatan;
    public float kecepatanAwal;
    private GameObject player;
    private Sanity sanity;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sanity = player.GetComponent<Sanity>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            // Debug.Log("Menyentuh Player");
            HitPlayer();
        }
    }

    void HitPlayer()
    {
        sanity.dark.intensity.value += Mathf.Lerp(0,0.4f,damage);

        // SFX kena hit / Jumpscare
        // AudioManager.Instance.PlaySfx("");
    }

}
