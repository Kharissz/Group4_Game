using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Sanity : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI;
    public VolumeProfile profile;
    public float ChargeRate;
    private Coroutine recharge;
    public Vignette dark;
    void Start()
    {
        profile.TryGet(out dark);
        dark.intensity.value = 0;
    }

    void Update()
    {
    }

    void getHit()
    {

        // dark.intensity.value += Mathf.Lerp(0,0.4f,damage);

        if(recharge != null) StopCoroutine(recharge);
        recharge = StartCoroutine(LoseSanity());

        if(dark.intensity.value >= .4f)
        {
            // SFX GameOver
            // AudioManager.Instance.PlaySfx("");
            
            gameOverUI.SetActive(true);
            Time.timeScale = 0;
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
            getHit();
            // Debug.Log("Terserang Hantu");
        }
    }
}
