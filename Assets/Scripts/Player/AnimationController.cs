using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
   
    Animator animator;
    PlayerMovement playerMovement;
    PlayerAttack playerAttack;
    PlayerJump playerJump;
    PlayerHealth playerHealth;
    bool attackAnimation;
   
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        playerMovement = GetComponentInParent<PlayerMovement>();
        playerAttack =GetComponentInChildren<PlayerAttack>();
        playerJump = GetComponentInParent<PlayerJump>();
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
