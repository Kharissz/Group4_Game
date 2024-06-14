using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] Transform[] point;
    [SerializeField] Hantu hantu;
    private Animator anim;
    private int i;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Patroling();
    }

    public void Patroling()
    {
        if (Vector2.Distance(transform.position,point[i].position) < 0.02f)
        {
            i++;
            if(i == point.Length) i = 0;
            if(i == 0) transform.localScale = new Vector3(1,1,1);
            else if(i == 1) transform.localScale = new Vector3(-1,1,1);

        }

        transform.position = Vector2.MoveTowards(transform.position, point[i].position, Mathf.Lerp(hantu.kecepatanAwal,hantu.kecepatan,.5f) * Time.deltaTime);
        anim.SetFloat("Walking",hantu.kecepatan);
    }
}
