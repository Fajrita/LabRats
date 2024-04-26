using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 400;
    PlayerInput playerInput;
    [SerializeField] PlayerAttack playerAttack;
    public Rigidbody2D rb;
    public Vector2 movement;
    public float direction;
    public float kBCounter;
    public Vector2 kBForce;
    public float kBTotalTime;
    public bool knockFromRight;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
       
        if(playerAttack.isAttacking)
        {
            movement.x = 0;
        } else
        {
            movement = playerInput.actions["Move"].ReadValue<Vector2>() * Time.fixedDeltaTime * speed;
        }

        kBCounter -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (kBCounter <= 0)
        {
            rb.velocity = new Vector2(movement.x, rb.velocity.y);
        }
              
        else
        {
            
        }

    }

   public void KnockBack(Vector2 kBForce, float knockbackTime)
    {
        if (knockFromRight)
        {
            rb.velocity = new Vector3(-kBForce.x, kBForce.y);
        }

        if (!knockFromRight)
        {
            rb.velocity = new Vector3(kBForce.x, kBForce.y);
        }

        
    }
}
