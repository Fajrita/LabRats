using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserY : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] PowerUpDataBase powerUpData;
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        rb.velocity = Vector2.right * speed;
    }


    void Update()
    {
        rb.velocity = Vector2.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Power"))
        {
            collision.gameObject.SetActive(false);
        }

        if (collision.CompareTag("Recieve"))
        {
            if (collision.GetComponent<PlayerHealth>().powerCountDown <= 0 && collision.GetComponent<PlayerHealth>())
            {
                int iD = Random.Range(1, powerUpData.powersList.Count);
                collision.transform.parent.parent.GetComponent<PowerUpManager>().GetPower(iD);
                collision.GetComponent<PlayerHealth>().powerCountDown = collision.GetComponent<PlayerHealth>().powerCooldown;
            }
            //npc
            if (collision.GetComponent<NPCHealth>().powerCountDown <= 0 && collision.GetComponent<NPCHealth>())
            {
                int iD = Random.Range(1, powerUpData.powersList.Count);
                collision.transform.parent.parent.GetComponent<NPCPowerUpManager>().GetPower(iD);
                collision.GetComponent<NPCHealth>().powerCountDown = collision.GetComponent<NPCHealth>().powerCooldown;
            }

        }
    }
}
