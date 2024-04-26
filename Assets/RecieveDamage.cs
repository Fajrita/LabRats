using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveDamage : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Damage"))
        //{
        Debug.Log("daño");
        //if(!isInmune)
        //{
        //        int damage = collision.transform.parent.GetComponent<PlayerAttack>().damage;
        //        RecibeDamage(damage);
        //}


        //}
    }
}
