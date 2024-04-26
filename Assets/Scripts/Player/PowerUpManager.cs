using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] PowerUpDataBase powerUpData;
    [SerializeField] GameObject playerTakePower;
 
    RatAttacks ratAttacks;

    PlayerMovement playerMovement;

    PlayerAttack playerAttack;

    PlayerJump playerJump;

    SpriteRenderer playerSprite;

    RuntimeAnimatorController animator;

    Sprite sprite;

    Sprite uiSprite;

    GameObject bullet;

    AudioClip iddleAudio;

    AudioClip attackAudio;

    AudioClip damageAudio;

    AudioClip effectAudio;

    Vector2 groundColliderOffset;

    Vector2 groundColliderSize;
    
    Vector2 kbForce;

    Color originalColor;

    int extraJumps;

    public int ID;

    public int damage;

    string name;
    
    float speed;

    float jumpForce;

    float gravityScale;

    float kbTotalTime;

    float attackCooldown;

    float stopMovingTime;

    bool isShooter;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponentInChildren<PlayerAttack>();
        playerJump =GetComponent<PlayerJump>();
        ratAttacks = GetComponentInChildren<RatAttacks>();
        
    }


    public void GetPower(int iD)
    {
        name = powerUpData.powersList[iD].name;
        ID = powerUpData.powersList[iD].iD;
        jumpForce = powerUpData.powersList[iD].jumpForce;
        extraJumps = powerUpData.powersList[iD].extraJumps;
        gravityScale = powerUpData.powersList[iD].gravityScale;
        sprite = powerUpData.powersList[iD].sprite;
        uiSprite = powerUpData.powersList[iD].uiSprite;
        kbForce = powerUpData.powersList[iD].kbForce;
        kbTotalTime = powerUpData.powersList[iD].kbTotalTime;
        speed = powerUpData.powersList[iD].speed;
        animator = powerUpData.powersList[iD].controller;
        attackCooldown = powerUpData.powersList[iD].attackCooldown;
        stopMovingTime = powerUpData.powersList[iD].stopMovingTime;
        groundColliderSize = powerUpData.powersList[iD].colliderSize;
        groundColliderOffset = powerUpData.powersList[iD].colliderOffset;
        //SHOOTERS
        isShooter = powerUpData.powersList[iD].isShooter;
        damage = powerUpData.powersList[iD].damage;
        bullet = powerUpData.powersList[iD].powerProyectil;
        //AUDIOS
        iddleAudio = powerUpData.powersList[iD].iddleAudioClip;
        attackAudio = powerUpData.powersList[iD].attackAudioClip;
        damageAudio = powerUpData.powersList[iD].damageAudioClip;
        effectAudio = powerUpData.powersList[iD].effectAudioClip;
        SetPower();
        
    }

    private void SetPower()
    {
        playerSprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        //AUDIOS
        if(iddleAudio == null )
        {
            GetComponentInChildren<AudioManager>().iddleClip = null;
        }
        GetComponentInChildren<AudioManager>().iddleClip = iddleAudio;
        GetComponentInChildren<AudioManager>().attackClip = attackAudio;
        GetComponentInChildren<AudioManager>().damageClip = damageAudio;
        GetComponentInChildren<AudioManager>().effectClip = effectAudio;
        originalColor = playerSprite.color;
        playerJump.jumpForce = jumpForce;
        playerJump.extraJumps = extraJumps;
        playerMovement.kBForce = kbForce;
        playerMovement.kBTotalTime = kbTotalTime;
        playerMovement.speed = speed;
        playerMovement.transform.gameObject.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        playerMovement.transform.gameObject.GetComponent<BoxCollider2D>().size = groundColliderSize; 
        playerMovement.transform.gameObject.GetComponent<BoxCollider2D>().offset = groundColliderOffset;
        gameObject.transform.GetComponentInChildren<Animator>().runtimeAnimatorController = animator;
        playerAttack.stopMovingTime = stopMovingTime;
        playerAttack.attackInterval = attackCooldown;
        playerAttack.damage = damage;
        //SHOOTERS
        playerAttack.isShooter = isShooter;
        ratAttacks.actualID = ID;
        ratAttacks.actualBullet = bullet;
        StartCoroutine("TakePower");
    }

    IEnumerator TakePower()
    {
        playerSprite.color = Color.yellow;
        yield return new WaitForSeconds(.2f);
        playerSprite.color = Color.white;
        playerSprite = null;
    }
    public void ResetStats()
    {
        GetPower(0);
    }
}


