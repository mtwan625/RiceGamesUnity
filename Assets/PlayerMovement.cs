using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 30f; // adjustable run speed
    float horizontalMove = 0f;
    bool isJumping = false;
    bool isCrouching = false;

    // get information from input every tick
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            animator.SetBool("isJumping", true);
        }

        if (Input.GetButtonDown("Crouch")) isCrouching = true;
        else if (Input.GetButtonUp("Crouch")) isCrouching = false;
    }

    void FixedUpdate()
    {
        // send movement information to controller
        controller.Move(horizontalMove * Time.fixedDeltaTime, isCrouching, isJumping);
        // reset values
        isJumping = false;
    }

    // function for OnLand() event from controller
    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    // function for OnCrouch event from controller
    public void OnCrouching(bool crouching)
    {
        animator.SetBool("isCrouching", crouching);
    }
}
