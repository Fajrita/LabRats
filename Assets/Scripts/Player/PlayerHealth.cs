using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerHealth : MonoBehaviour
{
    AudioManager audioManager;
    public KillManager killManager;
    public GameObject player;
    GameObject playerUI;
    [SerializeField] GameObject attackColliders;
    public HealthBar healthBar;
    Vector3[] respawnPoints;
    SpriteRenderer spriteRenderer;
    Collider2D recieveCollider;
    string playerID;
    public int health = 130;
    int maxHealth = 100;
    public bool isInmune;
    bool isBurning;
    public bool isDead;
    public float inmuneCounter;
    public float inmuneCooldown = 0.7f;
    public float respawnCountDown;
    public float respawnCooldown = 2f;
    public float powerCountDown;
    public float powerCooldown = 1.5f;

     void Start()
    {
        respawnPoints = new Vector3[3];
        respawnPoints[0] = new Vector3 (-4, 1.1f, 0);
        respawnPoints[1] = new Vector3(4, 1.1f, 0);
        respawnPoints[2] = new Vector3(0, -1f, 0);
        recieveCollider = GetComponent<Collider2D>();
        killManager = FindObjectOfType<KillManager>();
        playerID = player.name;
        inmuneCounter = inmuneCooldown;
        respawnCountDown = respawnCooldown;
        audioManager = GetComponentInParent<AudioManager>();
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
        GetPlayerUI(playerID);
    }

 

    void Update()
    {
        powerCountDown -= Time.deltaTime;
        if (isDead)
        {
            healthBar.SetHealth(0);
            recieveCollider.enabled = false;
            attackColliders.SetActive(false);
            respawnCountDown -= Time.deltaTime;
            player.GetComponentInChildren<SpriteRenderer>().enabled = false;
            player.transform.GetChild(2).gameObject.SetActive(true);
            player.GetComponentInChildren<Canvas>().enabled = false;
            player.GetComponent<Rigidbody2D>().gravityScale = 0f;
            player.GetComponent<Collider2D>().enabled = false;
            

            if (respawnCountDown <= 0)
            {
                player.transform.position = respawnPoints[UnityEngine.Random.Range(0, 3)];
                Respawn(player);
                isDead = false;
                respawnCountDown = respawnCooldown;
            }

        }

        if (isInmune)
        {
            inmuneCounter -= Time.deltaTime;
            if(inmuneCounter <= 0)
            {
                isInmune = false;
                inmuneCounter = inmuneCooldown;
            }

        }

        if (powerCountDown <= 0.5)
        {
            player.transform.GetChild(3).gameObject.SetActive(false);
        }
    }

    

    private void GetPlayerUI(string playerID)
    {
      switch (playerID) {

          
            case "Player01":
                playerID = "P1";
                break;
            case "Player02":
                playerID = "P2";
                break;
            case "Player03":
                playerID = "P3";
                break;
            case "Player04":
                playerID = "P4";
                break;
            default:
               
                break;
        } 

        playerUI = GameObject.Find(playerID);
        
        GetHealthBar(playerUI);
    }

    private void GetHealthBar(GameObject playerUI)
    {
        healthBar = playerUI.transform.GetChild(0).GetComponent<HealthBar>();
    }

    public void RecibeDamage(int damage, string playerHitting)
    {
        if (!isDead)
        {
            health -= damage;
            audioManager.RecibeDamage();
            if (health > maxHealth)
            {
                health = maxHealth;
            }
            if (health <= 0)
            {

                health = 0;
                isDead = true;
                killManager.AddKill(playerHitting);
                healthBar.SetHealth(health);
            }
            healthBar.SetHealth(health);
            StartCoroutine("TakeDamage");
        }

    }


    private void Respawn(GameObject player)
    {
        var letter = player.name.ToCharArray();
        var numchar = letter[7].ToString();
        var num = int.Parse(numchar);
        health = 130;
        healthBar.SetHealth(health);
        player.GetComponent<PowerUpManager>().ResetStats();
        player.GetComponentInChildren<Animator>().runtimeAnimatorController = SelectButtonManager.playersAnimCtrls[num - 1];
        player.transform.GetChild(2).gameObject.SetActive(false);
        player.GetComponentInChildren<SpriteRenderer>().enabled = true;
        player.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        player.GetComponent<Rigidbody2D>().gravityScale = 10f;
        player.GetComponent<Collider2D>().enabled = true;
        player.GetComponentInChildren<Canvas>().enabled = true;
        attackColliders.SetActive(true);
        recieveCollider.enabled = (true);
        isInmune = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damage"))
        {
            if (!isInmune)
            {
                //Encuentra quien golpea
                GameObject colliderHit = collision.transform.parent.gameObject;
                GameObject playerHitting = colliderHit.transform.parent.parent.gameObject;
                string playerName = playerHitting.name;
                //Cambios Faj
                int damage= 0;
                if (!collision.gameObject.GetComponentInParent<PlayerAttack>())
                {
                    damage = collision.gameObject.GetComponentInParent<NPCAttack>().damage;
                }
                if(!collision.gameObject.GetComponentInParent<NPCAttack>())
                {
                    damage = collision.gameObject.GetComponentInParent<PlayerAttack>().damage;
                    
                }

                //int damage = collision.gameObject.GetComponentInParent<PlayerAttack>().damage;
                //knockBack

                if (!playerHitting.GetComponent<PlayerMovement>())
                {
                    player.GetComponent<PlayerMovement>().KnockBack(playerHitting.GetComponent<FindTarget>().kBForce, playerHitting.GetComponent<FindTarget>().kBTotalTime);
                    player.GetComponent<PlayerMovement>().kBCounter = playerHitting.GetComponent<FindTarget>().kBTotalTime;
                }
                
                player.GetComponent<PlayerMovement>().KnockBack(playerHitting.GetComponent<PlayerMovement>().kBForce, playerHitting.GetComponent<PlayerMovement>().kBTotalTime);
                player.GetComponent<PlayerMovement>().kBCounter = playerHitting.GetComponent<PlayerMovement>().kBTotalTime;
                //OJO AQUI ------------------------------------------------------------------------------------------------------------------
                if (collision.transform.position.x >= player.transform.position.x)
                {
                    player.GetComponent<PlayerMovement>().knockFromRight = true;
                }
                if (collision.transform.position.x <= player.transform.position.x)
                {
                    player.GetComponent<PlayerMovement>().knockFromRight = false;
                }
                //RecibeDano
                RecibeDamage(damage, playerName);
            }
           
        }

       
        if (collision.transform.CompareTag("Bullet"))
        {
            //La bala del player no le pega a si mismo
            if (collision.GetComponent<BulletData>().killerName == playerID)
            {

            } else 
            {
                if (!isInmune)
                {

                    string playerName = collision.gameObject.GetComponent<BulletData>().killerName;
                    int damage = collision.gameObject.GetComponent<BulletData>().damageToDeal;
                    RecibeDamage(damage, playerName);
                    Destroy(collision.gameObject);
                }

            }
            

        }
        if (collision.CompareTag("Power"))
        {
            if (powerCountDown <= 0)
            {

                int iD = collision.GetComponent<PowerScript>().iD;
                player.GetComponent<PowerUpManager>().GetPower(iD);
                player.transform.GetChild(3).gameObject.SetActive(true);
                powerCountDown = powerCooldown;
            }
            
        }

        if (collision.CompareTag("Laser"))
        {
            if (powerCountDown <= 0)
            {
                int iD = Random.Range(1, 17);
                player.GetComponent<PowerUpManager>().GetPower(iD);
                player.transform.GetChild(3).gameObject.SetActive(true);
                powerCountDown = powerCooldown;
            }
        }
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
        //if (collision.transform.CompareTag("Damage"))
        //{
        //    if (!isInmune)
        //    {
        //        GameObject playerHitting = collision.gameObject;
        //        string playerName = collision.gameObject.name;
        //        int damage = collision.gameObject.GetComponentInParent<PlayerAttack>().damage;
        //        RecibeDamage(damage, playerName);
        //    }
           
        //}

        //if (collision.transform.CompareTag("Bullet"))
        //{
        //    if (collision.transform.GetComponent<BulletData>().killerName == playerID)
        //    {

        //    }
        //    else
        //    {
        //        if (!isInmune)
        //        {
        //            GameObject playerHitting = collision.gameObject;
        //            string playerName = collision.gameObject.name;
        //            int damage = collision.gameObject.GetComponentInParent<PlayerAttack>().damage;
        //            RecibeDamage(damage, playerName);
        //        }
        //    }
            

        //}
   // }
    IEnumerator TakeDamage()
    {
       
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(.2f);
        spriteRenderer.color = Color.white;
    }


}
