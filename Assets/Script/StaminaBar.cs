using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Image BarStamina;

    public float MaxStamina,Stamina;
    public float RunCost,AttackCost,ChargeRate;

    private Coroutine recharge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Stamina_Move()
    {
         if(Stamina < 0) 
            {Stamina = 0;}

            Stamina-= RunCost * Time.deltaTime;
            BarStamina.fillAmount =  Stamina / MaxStamina;
            
        // Recharge Stamina Bar
        if(recharge != null) StopCoroutine(recharge);
        recharge = StartCoroutine(Cooldown());
    }

    public void Stamina_Attack()
    {
         if(Stamina < 0) 
            {Stamina = 0;}

            Stamina-= AttackCost;
            BarStamina.fillAmount =  Stamina / MaxStamina;
        
        // Recharge Stamina Bar
        if(recharge != null) StopCoroutine(recharge);
        recharge = StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1f);

        while(Stamina < MaxStamina)
        {
            Stamina+=ChargeRate / 10f;
            if(Stamina>MaxStamina) Stamina = MaxStamina;
            BarStamina.fillAmount = Stamina / MaxStamina;
            yield return new WaitForSeconds(.1f);
        }

    }
}
