using System.Collections;
using System.Collections.Generic;
// using System.Diagnostics;
using UnityEngine;

public class Hantu : MonoBehaviour
{
    // Komponen Sensor Start
    public float damage;
    [SerializeField]
    Transform rayPoint;

    public float rayDistance;

    [SerializeField]
    Transform player;

    private int layerIndex;

    Vector2 dir;
    // Komponen Sensor END

    // Komponen Gerak START
    public float kecepatan;
    public int awal;
    [SerializeField]
    Transform[] point;

    private int i;
    // Komponen Gerak END

    // Komponen Animasi Start
    private Animator anim;
    // Komponen Animasi Start


    // Start is called before the first frame update
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Kejar();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
    }

    void Movement()
    {
        if (Vector2.Distance(transform.position,point[i].position) < 0.02f)
        {
            i++;
            if(i == point.Length) i = 0;
            if(i == 0) transform.localScale = new Vector3(1,1,1);
            else if(i == 1) transform.localScale = new Vector3(-1,1,1);

        }

        transform.position = Vector2.MoveTowards(transform.position, point[i].position, kecepatan * Time.deltaTime);
        anim.SetFloat("Walking",kecepatan);
    }

    void Kejar()
    {
        // Enemy Facing START
        if(player.position.x < transform.position.x) transform.localScale = new Vector3(-1,1,1);
        else if(player.position.x > transform.position.x) transform.localScale = new Vector3(1,1,1);
        // Enemy Facing END
        
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position,dir,rayDistance);
        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {

        }

        Debug.DrawRay(rayPoint.position,Vector2.left * rayDistance, Color.green);

    }

    void Animasi()
    {

    }
}
