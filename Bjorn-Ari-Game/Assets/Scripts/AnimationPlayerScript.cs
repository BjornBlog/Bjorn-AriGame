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
        bool forwardPressed = Input.GetKey("w");
        if(isWalking && forwardPressed)
        {
            animator.SetBool("isWalking", true);
        }
        if(isWalking && !forwardPressed)
        {
            animator.SetBool("isWalking", false);
        }

        if(!isRunning && (forwardPressed && runPressed))
        {
            animator.SetBool("isRunning", true);
        }
        if(!isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool("isRunning", false);
        }
    }
}
