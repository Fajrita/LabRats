using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] PowerUpDataBase powerUpData;
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;
    }

    
    void Update()
    {
        rb.velocity = Vector2.down * speed;
        if (transform.position.y < -20f)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Power"))
        {
           collision.gameObject.SetActive(false);
        }

        
    }
}
