using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{
    public StaminaBar stamina;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();        
    }

    void Attack()
    {
        if(Input.GetKeyDown("f"))
        {
            if(stamina.Stamina >= 50)
            {
                print("Attack");
                stamina.Stamina_Attack();
            }

        }

    }
}
