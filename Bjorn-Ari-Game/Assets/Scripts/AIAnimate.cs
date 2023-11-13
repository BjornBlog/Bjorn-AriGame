using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimate : MonoBehaviour
{    
    private Animator animator;
    private AI movementScript;
    [SerializeField]
    private GameObject enemyRoot;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        movementScript = enemyRoot.GetComponent<AI>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isMoving = animator.GetBool("isMoving");
        bool isAttacking = animator.GetBool("isAttacking");
        bool isHunting = animator.GetBool("isHunting");
        bool isIdle = animator.GetBool("isIdle");
        if(movementScript != null)
        {   if(!movementScript.idle)
            {   
                if(movementScript.moving)
                {
                    animator.SetBool("isMoving", true);
                }
                else if(movementScript.hunting)
                {
                    animator.SetBool("isHunting", true);
                }
            }
            else if(movementScript.idle)
            {
                animator.SetBool("isIdle", true);
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        print("Collide");
        if(other.gameObject.tag == "Player")
        {
            animator.SetBool("isAttacking", true);
        }
    }
}
