using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimate : MonoBehaviour
{    
    private Animator animator;
    private AI MovementScript;
    [SerializeField]
    private GameObject enemyRoot;
    private bool striking = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        MovementScript = enemyRoot.GetComponent<AI>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isMoving = animator.GetBool("isMoving");
        bool moving = MovementScript.Moving();
        bool isAttacking = animator.GetBool("isAttacking");
        bool isHunting = animator.GetBool("isHunting");
        bool hunting = MovementScript.Hunting();
        bool isIdle = animator.GetBool("isIdle");
        if(MovementScript != null)
        {   if(moving && !hunting && !striking)
            {
                print("Enemy walk");
                animator.SetBool("isMoving", true);
            }
            if(!moving)
            {
                animator.SetBool("isMoving", false);
            }
            if(hunting && !striking)
            {
                print("Enemy run");
                animator.SetBool("isHunting", true);
            }
            if(!hunting)
            {
                animator.SetBool("isHunting", false);
            }
            if(!moving && !hunting && !striking)
            {
                print("Enemy idle");
                animator.SetBool("isIdle", true);
            }
            else
            {
                animator.SetBool("isIdle", false);
            }
        }
        else
        {
            print("NO Movement Script");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        print("InStrikeZone");
        if(other.gameObject.tag == "Player")
        {
            striking = true;
            print("Enemy strike");
            animator.SetBool("isAttacking", true);
        }
    }
}
