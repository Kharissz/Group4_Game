using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{
    private StaminaBar stamina;
    private Animator anim;
    public float attackRate = 2f;
    public Transform attackpoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public int attackDamage = 20;
    void Start()
    {
        stamina = GetComponent<StaminaBar>();
        anim = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        if(stamina.Stamina >=50)
        {
            if(Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Attack");
            }  
        }
        
    }

    void Attack()
    {

            // 1. Jalankan animasi menyerang
            stamina.Stamina_Attack();
        


        // 2. Deteksi musuh yang terkena
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemyLayers);
        // Collider2D[] hitBoss = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemyLayers);


        // 3. Kasih damage
        foreach(Collider2D enemy in hitEnemies)
        {
 
            enemy.GetComponent<Hantu>().TakeDamage();
        }

    }
    
    void OnDrawGizmosSelected()
    {
        if(attackpoint == null)
            return;
        Gizmos.DrawWireSphere(attackpoint.position,attackRange);
    }
}
