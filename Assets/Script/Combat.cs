using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{
    bool equip = false;
    private StaminaBar stamina;
    private Animator anim;
    void Start()
    {
        stamina = GetComponent<StaminaBar>();
        anim = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        // Attack();
        if(Input.GetMouseButtonDown(0) && equip)
        {
            anim.SetTrigger("Attack");
        }  
    }

    public void Attack()
    {
            if(stamina.Stamina >= 50)
            {stamina.Stamina_Attack();}

    }
}
