using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimationController : MonoBehaviour
{
   
    Animator animator;
    FindTarget playerMovement;
    PlayerAttack playerAttack;
    NPCJump playerJump;
    PlayerHealth playerHealth;
    bool attackAnimation;
   
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        playerMovement = GetComponentInParent<FindTarget>();
        playerAttack =GetComponentInChildren<PlayerAttack>();
        playerJump = GetComponentInParent<NPCJump>();
        playerHealth = GetComponentInChildren<PlayerHealth>();
    }

    
    void Update()
    {
        animator.SetFloat("movX", playerMovement.movement.x);
        animator.SetBool("isGrounded", playerJump.isGrounded);
        if(playerMovement.movement.x == 0)
        {
            animator.SetBool("isMoving", false);
        } else
        {
            animator.SetBool("isMoving", true);
        }

        if (attackAnimation)
        {
            animator.SetTrigger("Attack");
            attackAnimation = false;
        }
        
    }

    public void AttackAnimation()
    {
        attackAnimation = true;
    }


}
