using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCAttack : MonoBehaviour
{
    FindTarget playerMovement;
    NPCAnimationController animationController;
    SpriteRenderer spriteRenderer;
    RatAttacks ratAttacks;

    [SerializeField] public int damage = 10;
    [SerializeField] public float attackInterval;

    public bool isShooter;
    public bool isAttacking;
    public bool attackingAnimation;
    bool isFacingRigth;

    float coolDown;
    float stopMovingCountDown;
    public float stopMovingTime;
   
    public Vector2 lastPosition = new Vector2(0,0);
    GameObject thisParent;
    public GameObject bullet;
    

   
    
    
    
    void Start()
    {
        thisParent = gameObject.transform.parent.gameObject;
        ratAttacks = GetComponent<RatAttacks>();
        animationController = GetComponentInParent<NPCAnimationController>();
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
        playerMovement = thisParent.GetComponentInParent<FindTarget>();
        if(!spriteRenderer.flipX)
        {
            isFacingRigth = true;
        }
    }

    
    void Update()
    {
        lastPosition = playerMovement.movement;
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }

        
        if (lastPosition.x < 0)
        {
          
            isFacingRigth = false;
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        if (lastPosition.x > 0)
        {
            isFacingRigth = true;
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        if (isAttacking)
        {
            
            stopMovingCountDown -= Time.deltaTime;
            if(stopMovingCountDown <= 0) 
            {
                isAttacking = false;
          
            }
        }
        
    }

    public void OnAttack()
    {
            if (coolDown <= 0)
            {
                stopMovingCountDown = stopMovingTime;
                isAttacking = true;
                coolDown = attackInterval;
                Attack();
            } 
    }

    private void Attack()
    {
        if (isShooter)
        {
            ratAttacks.SearchAttack(damage,thisParent.transform.parent.name, isFacingRigth);
            animationController.AttackAnimation();      
        }
        else 
        {
            animationController.AttackAnimation();     
        }   
    }



}
