using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomBulletBehaviour : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField] float lifeTime = 2.5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

       
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
        if (collision.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
