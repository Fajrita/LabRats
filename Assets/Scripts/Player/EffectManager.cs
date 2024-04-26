using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    Color orange = new Color(1.0f, 0.64f, 0.0f);
    PlayerHealth playerHealth;
    GameObject player;
    SpriteRenderer spriteRenderer;
    bool isBurning;
    float burningCountDown;
    float burningDuration = 3f;
    void Start()
    {
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
        playerHealth = GetComponent<PlayerHealth>();
        player = playerHealth.player;
        burningCountDown = burningDuration;
    }


    void Update()
    {
        if (isBurning)
        {
            spriteRenderer.color = orange;
            burningCountDown -= Time.deltaTime;

            if (burningCountDown <= 0)
            {
                spriteRenderer.color = Color.white;
                isBurning = false;
            }
        }
        
        
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fire"))
        {
            if (!playerHealth.isInmune)
            {
                burningCountDown = burningDuration;
                isBurning = true;
                GameObject colliderHit = collision.transform.parent.gameObject;
                GameObject playerHitting = colliderHit.transform.parent.parent.gameObject;
                string playerName = playerHitting.name;
                int damage = collision.gameObject.GetComponentInParent<PlayerAttack>().damage;
                //knockBack
                player.GetComponent<PlayerMovement>().kBForce = playerHitting.GetComponent<PlayerMovement>().kBForce;
                player.GetComponent<PlayerMovement>().kBCounter = player.GetComponent<PlayerMovement>().kBTotalTime;
                if (collision.transform.position.x >= player.transform.position.x)
                {
                    player.GetComponent<PlayerMovement>().knockFromRight = true;
                }
                if (collision.transform.position.x <= playerHealth.transform.position.x)
                {
                    player.GetComponent<PlayerMovement>().knockFromRight = false;
                }
                //RecibeDa�o
                int totalDamage = 30;
                int duration = 3;
                playerHealth.RecibeDamage(damage, playerName);
                StartCoroutine(DamageOverTime(playerName,totalDamage,duration));
                

            }
        }     

    }

    IEnumerator DamageOverTime(string playerName, int totalDamage, int duration)
    {
        
        float damageDealth = 0;
        int damagePerLoop = totalDamage / duration;
        while (damageDealth < totalDamage) 
        {
            spriteRenderer.color = orange;
            playerHealth.health -= damagePerLoop;
            damageDealth += damagePerLoop;
            playerHealth.healthBar.SetHealth(playerHealth.health);
            if (playerHealth.health <= 0)
            {
                if (!playerHealth.isDead)
                {
                    playerHealth.health = 0;
                    playerHealth.isDead = true;
                    burningCountDown = 0;
                    playerHealth.killManager.AddKill(playerName);
                    damageDealth = totalDamage;
                    isBurning = false;
                }
            }
            yield return new WaitForSeconds(1f);
        }
        
    }

    
}
