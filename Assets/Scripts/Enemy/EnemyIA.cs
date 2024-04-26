using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    int health = 100;
    Collider2D col;
    SpriteRenderer spriteRenderer;
    Color originalColor;
    void Start()
    {
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AttackPlayer"))
        {
            health -= 10;
            StartCoroutine("TakeDamage");
            Debug.Log(health);
        }
    }


    IEnumerator TakeDamage()
    {
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(.1f);
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(.1f);
        spriteRenderer.color = originalColor;
    }
}
