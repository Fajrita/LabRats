using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletData : MonoBehaviour
{
    public string killerName;
    public int damageToDeal;
    Rigidbody2D rb;
    public float speed;
    public bool isRight;
    private void Start()
    {
        

    }


    public void SetDataBulletData(int damage, string playerName, bool isFacingRight)
    {
        damageToDeal = damage;
        killerName = playerName;
        isRight = isFacingRight;
    }
}
