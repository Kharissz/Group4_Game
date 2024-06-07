using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Sanity : MonoBehaviour
{
    public VolumeProfile profile;
    public float ChargeRate;
    private Coroutine recharge;
    Vignette dark;
    public Hantu ghost;
    // Start is called before the first frame update
    void Start()
    {
        profile.TryGet(out dark);
        dark.intensity.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void getHit(float damage)
    {

        dark.intensity.value += Mathf.Lerp(0,0.4f,damage);

        if(recharge != null) StopCoroutine(recharge);
        recharge = StartCoroutine(LoseSanity());

        if(dark.intensity.value >= .4f)
        {
            print("You're Nuts");
        }
    }

    private IEnumerator LoseSanity()
    {
        yield return new WaitForSeconds(1f);

        while(dark.intensity.value > 0)
        {
            dark.intensity.value-=ChargeRate/100f;
            if(dark.intensity.value < 0) dark.intensity.value = 0;
            yield return new WaitForSeconds(.1f);
        }
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "hantu")
        {
            getHit(ghost.damage);
        }
    }
}
