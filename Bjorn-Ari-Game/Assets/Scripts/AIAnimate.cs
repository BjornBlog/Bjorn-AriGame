using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimate : MonoBehaviour
{    
    private Animator animator;
    UnityEngine.AI.NavMeshAgent agent;
    [SerializeField]
    private GameObject enemyRoot;
    private bool striking = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = enemyRoot.GetComponent<Animator>();
        agent = enemyRoot.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        animator.SetFloat("Speed", agent.velocity.magnitude / 6);
    }
    private IEnumerator Attack()
    {
        striking = true;
        print("Enemy strike");
        animator.SetBool("isAttacking", true);
        yield return new WaitForSeconds(2);
        animator.SetBool("isAttacking", false);
    }
    private void OnTriggerEnter(Collider other)
    {
        print("InStrikeZone");
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(Attack());
        }
    }
}
