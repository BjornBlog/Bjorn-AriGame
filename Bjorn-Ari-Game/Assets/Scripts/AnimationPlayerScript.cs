using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayerScript : MonoBehaviour
{
    private Animator animator;
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
       animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool("isRunning");
        bool runPressed = Input.GetKey("left shift");
        bool isWalking = animator.GetBool("isWalking");
        bool forwardPressed = Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("d");
        bool isJumping = animator.GetBool("isJumping");
        bool upPressed = Input.GetKey("space");
        bool isCrouching = animator.GetBool("isCrouching");
        bool downPressed = Input.GetKey(KeyCode.LeftControl);
        bool isCwalking = animator.GetBool("isCwalking");
        bool cforwardPressed = Input.GetKey(KeyCode.LeftControl) && (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"));
        bool isBwalking = animator.GetBool("isBwalking");
        bool backwardsPressed = Input.GetKey("s");

        if (forwardPressed)
        {
            animator.SetBool("isWalking", true);
        }
        if (!forwardPressed)
        {
             animator.SetBool("isWalking", false);
        }
        if (runPressed && forwardPressed)
        {
            animator.SetBool("isRunning", true);
        }
        if (!runPressed || !forwardPressed)
        {
            animator.SetBool("isRunning", false);
        }
        if (upPressed)
        {
            animator.SetBool("isJumping", true);
        }
        if (!upPressed)
        {
            animator.SetBool("isJumping", false);
        }
        if (downPressed)
        {
            animator.SetBool("isCrouching", true);
        }
        if (!downPressed)
        {
            animator.SetBool("isCrouching", false);
        }
        if (cforwardPressed)
        {
            animator.SetBool("isCwalking", true);
        }
        if (!cforwardPressed)
        {
            animator.SetBool("isCwalking", false);
        }
        if (backwardsPressed)
        {
            animator.SetBool("isBwalking", true);
        }
        if (!backwardsPressed)
        {
            animator.SetBool("isBwalking", false);
        }
        // if(isWalking && forwardPressed)
        // {
        //     animator.SetBool("isWalking", true);
        // }
        // if(isWalking && !forwardPressed)
        // {
        //     animator.SetBool("isWalking", false);
        // }

        // if(!isRunning && (forwardPressed && runPressed))
        // {
        //     animator.SetBool("isRunning", true);
        // }
        // if(!isRunning && (!forwardPressed || !runPressed))
        // {
        //     animator.SetBool("isRunning", false);
        // }
    }
}
