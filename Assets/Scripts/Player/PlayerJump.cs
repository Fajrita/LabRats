using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerJump : MonoBehaviour
{

    Rigidbody2D rb;
    public float jumpForce;
    public bool isGrounded;
    public int extraJumps;
    int jumpCount;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(jumpCount);
        if (isGrounded)
        {
            jumpCount = extraJumps;
        }
    }

    public void OnJump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            if (jumpCount > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpCount--;
            }
            else
            {
                if(isGrounded)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }
                
            }
           
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground") || collision.transform.CompareTag("Platform"))
        {
            
            isGrounded = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground") || collision.transform.CompareTag("Platform"))
        {
            isGrounded = false;
        }

        

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground") || collision.transform.CompareTag("Platform"))
        {

            isGrounded = true;
        }

    }

}
