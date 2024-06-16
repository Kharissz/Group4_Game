using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    [SerializeField] private Stationer stationer;
    private GameObject player;
    // private Hantu hantu;
    private Hiding isHide;
    public float speed;
    public float distance;
    public float distanceBetween;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isHide = player.GetComponent<Hiding>();
        // hantu = GetComponent<Hantu>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isHide.isHiding || distance > distanceBetween)
        {
            // Invoke("Back",3f);
            stationer.Stationing();
        }
        else
        {
            Chase();
        }
        distance = Vector2.Distance(transform.position, player.transform.position);
    }

    void Chase()
    {
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        // Jika masuk jangkauan dan player tidak sembunyi
        if(distance < distanceBetween && !isHide.isHiding)
        {
            transform.position = Vector2.MoveTowards(this.transform.position,player.transform.position, speed*Time.deltaTime);
            if(player.transform.position.x < transform.position.x) transform.localScale = new Vector3(-1,1,1);
            else 
            {transform.localScale = new Vector3(1,1,1);} 
        }
    }

    void Back()
    {
        stationer.Stationing();    
    }
}
