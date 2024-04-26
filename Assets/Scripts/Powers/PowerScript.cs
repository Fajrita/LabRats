using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class PowerScript : MonoBehaviour
{
   
    [SerializeField] PowerUpDataBase powerUpData;
    int powerUpIndex = 1;
    public int iD;
    bool isGrounded;
    Rigidbody2D rb;


    void Awake()
    {
       //powerUpIndex = 18;
        powerUpIndex = Random.Range(1,19);
        GetPoweUpData(powerUpIndex);
      
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1f;
    }

    private void OnEnable()
    {
        GetNewPower();
    }

    

    void Update()
    {
        if (isGrounded)
        {
            rb.velocity = Vector3.zero;
            rb.gravityScale = 0;

        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    private void GetPoweUpData(int powerUpIndex)
    {
       
        iD = powerUpData.powersList[powerUpIndex].iD;
      
    }

    private void GetNewPower()
    {
        //powerUpIndex = 18;
        powerUpIndex = Random.Range(1, 19);
        GetPoweUpData(powerUpIndex);
    
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.transform.CompareTag("Recieve"))
        {
            gameObject.SetActive(false);
        }

       if (collision.CompareTag("Ground") || collision.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }

}
