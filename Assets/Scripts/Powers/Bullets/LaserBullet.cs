using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (GetComponent<BulletData>().isRight)
        {
            rb.velocity = transform.right * GetComponent<BulletData>().speed;
        }
        else
        {
            rb.velocity = -transform.right * GetComponent<BulletData>().speed;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
