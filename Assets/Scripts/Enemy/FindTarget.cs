using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FindTarget : MonoBehaviour
{
    public float speed = 10;
    public float jumpSpeed = 100;
    public float kBCounter;
    public Vector2 kBForce;
    public float kBTotalTime;
    public bool knockFromRight;

    public Vector2 direction;
    public Vector2 movement;
    public LayerMask walls;
    public LayerMask playerLayer;
    public LayerMask power;

    Collider2D nearerplataform;
    NPCJump nPCJump;
    public NPCAttack nPCAttack;
    public NPCPowerUpManager nPCPowerUpManager;
    public Rigidbody2D rb;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nPCJump = GetComponent<NPCJump>();


    }
    void FixedUpdate()
    {
        Collider2D[] plataform = Physics2D.OverlapCircleAll(transform.position, 500, walls);
        Collider2D[] players = Physics2D.OverlapCircleAll(transform.position, 500, playerLayer);
        Collider2D[] powers = Physics2D.OverlapCircleAll(transform.position, 500, power);

        if(nPCPowerUpManager.ID == 0 && powers.Length > 0)
        {
            float distX;
            float distY;
            Collider2D nearPower = null;
            float smallestDistPower = 1000;

            foreach(Collider2D p in powers)
            {
                float distance = Vector2.Distance(p.transform.position, transform.position);

                if (smallestDistPower > distance)
                {
                    smallestDistPower = distance;   
                    nearPower = p;
                }
            }
            distX = (nearPower.transform.position.x - transform.position.x);
            distY = (nearPower.transform.position.y - transform.position.y);
            float velX = distX;


            if (distY < 1f)
            {
                if (distX < -1f) distX = -1;
                else if (distX >1f) distX = 1;
                else distX = 0;
                velX = distX;
                movement = new Vector2(velX, 0) * Time.fixedDeltaTime * speed;
            }


            else if (distY > 1f)
            {
                List<Collider2D> Yplataforms = new List<Collider2D>();
                float smallestDistY = 1000;
                float smallestDistX = 1000;

                foreach (Collider2D collider in plataform)
                {
                    var plataformDistY = collider.transform.position.y - transform.position.y;
                    if (smallestDistY == plataformDistY)
                    {
                        Yplataforms.Add(collider);
                    }
                    if (smallestDistY > plataformDistY)
                    {
                        smallestDistY = plataformDistY;
                        Yplataforms.Clear();
                        Yplataforms.Add(collider);
                    }

                }

                foreach (Collider2D collider in Yplataforms)
                {
                    var plataformDistX = (nearPower.transform.position.x - collider.transform.position.x);

                    if (smallestDistX > Mathf.Abs(plataformDistX))
                    {
                        smallestDistX = Mathf.Abs(plataformDistX);
                        nearerplataform = collider;
                    }
                }
                distX = (nearerplataform.transform.position.x - transform.position.x);
                if (distX < -1f) distX = -1;
                else if (distX > 1f) distX = 1;
                else distX = 0;
                velX = distX;
                movement = new Vector2(velX, 0) * Time.fixedDeltaTime * speed;
                if (distX == 0)
                {
                    nPCJump.OnJump();
                }
            }
            else distY = 0;


            //////////////////////PLAYER///////////////////////////////////////
        }
        else
        {
            Debug.Log(players.Length);
            if (players.Length > 0)
            {
                
                float smallestDistPlayer = 1000;
                Collider2D player = null;
                foreach (var p in players)
                {
                    if (p.gameObject.name != this.name)
                    {
                        float distance = Vector2.Distance(p.transform.position, transform.position);
                        if (smallestDistPlayer > distance)
                        {

                            smallestDistPlayer = distance;
                            player = p;
                        }

                    }
                       
                }
                Debug.Log(player.gameObject.name);

                if (player != null)
                {
                    float distX = (player.transform.position.x - transform.position.x);
                    float distY = (player.transform.position.y - transform.position.y);
                    float velX = distX;

                    if (distY < 2)
                    {
                        if (distX < -2) distX = -1;
                        else if (distX > 2) distX = 1;
                        else distX = 0;
                        velX = distX;
                        movement = new Vector2(velX, 0) * Time.fixedDeltaTime * speed;

                        if (distX == 0)
                        {
                            Debug.Log("atac");
                            nPCAttack.OnAttack();
                        }
                    }


                    else if (distY > 2)
                    {
                        List<Collider2D> Yplataforms = new List<Collider2D>();
                        float smallestDistY = 100;
                        float smallestDistX = 100;

                        foreach (Collider2D collider in plataform)
                        {
                            var plataformDistY = collider.transform.position.y - transform.position.y;
                            if (smallestDistY == plataformDistY)
                            {
                                Yplataforms.Add(collider);
                            }
                            if (smallestDistY > plataformDistY)
                            {
                                smallestDistY = plataformDistY;
                                Yplataforms.Clear();
                                Yplataforms.Add(collider);
                            }

                        }

                        foreach (Collider2D collider in Yplataforms)
                        {
                            var plataformDistX = (player.transform.position.x - collider.transform.position.x);

                            if (smallestDistX > Mathf.Abs(plataformDistX))
                            {
                                smallestDistX = Mathf.Abs(plataformDistX);
                                nearerplataform = collider;
                            }
                        }
                        distX = (nearerplataform.transform.position.x - transform.position.x);
                        if (distX < -2) distX = -1;
                        else if (distX > 2) distX = 1;
                        else distX = 0;
                        velX = distX;
                        movement = new Vector2(velX, 0) * Time.fixedDeltaTime * speed;
                        if (distX == 0)
                        {
                            nPCJump.OnJump();
                        }
                    }
                    else distY = 0;

                    if (distX == 0 && distY == 0)
                    {
                        nPCAttack.OnAttack();
                    }

                }

                
            }
        }

        if (kBCounter <= 0)
        {
            rb.velocity = new Vector2(movement.x, rb.velocity.y);
        }
        else
        {
        }
    }

    public void KnockBack(Vector2 kBForce, float knockbackTime)
    {
        if (knockFromRight)
        {
            rb.velocity = new Vector3(-kBForce.x, kBForce.y);
        }

        if (!knockFromRight)
        {
            rb.velocity = new Vector3(kBForce.x, kBForce.y);
        }


    }
}
