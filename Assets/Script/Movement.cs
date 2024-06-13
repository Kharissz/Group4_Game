using System;
using System.Collections;
using System.Collections.Generic;
// using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public CharacterController2D script;

    public Animator anim;

    public float runSpeed = 20f;

    public float  horizontalMove = 0f;

    bool jump = false;

    bool crouch = false;

    bool running;

    public StaminaBar stamina;
    [SerializeField] private Hiding hiding;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        anim.SetFloat("Running", Math.Abs(horizontalMove));
        
        if (Input.GetButtonDown("Jump"))
        {Jummping(hiding.isHiding);}
        
        if (Input.GetButtonDown("Crouch"))
        {crouch = true;}
        else if (Input.GetButtonUp("Crouch"))
        {crouch = false;}

        if(Input.GetKeyDown("left shift"))
        {running = true;}
        if(Input.GetKeyUp("left shift"))
        {running = false;}
    }

    void FixedUpdate()
    {  
        script.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        
        // Mekanisme Lari
        if(running && (horizontalMove != 0) && stamina.Stamina > 0)
        {
            script.Move(horizontalMove * 2 * Time.fixedDeltaTime, crouch, jump);
            stamina.Stamina_Move();
        }

        jump = false;
    }

    public void OnLanding()
    {

        anim.SetBool("isJumping", false);
    }

    public void OnCrouching (bool isCrouching)
    {
        // anim.SetBool("isCrouching", isCrouching);
    }

    void Jummping(bool hide)
    {
        if(!hide)jump = true;
        // Loncat
        anim.SetBool("isJumping", jump); 
    }

}
