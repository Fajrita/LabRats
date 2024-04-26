using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoveBullet : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float lifeTime = 2.5f;
    LayerMask WallsLayer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = Vector3.down * GetComponent<BulletData>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("Platform"))
        {
            Destroy(gameObject);
        }
    }

}
