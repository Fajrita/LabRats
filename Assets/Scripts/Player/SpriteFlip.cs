using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlip : MonoBehaviour
{
    PlayerMovement playerMovement;
    SpriteRenderer spriteRenderer;
    Vector2 lastPosition;
    void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
        lastPosition = playerMovement.movement;

        if (lastPosition.x < 0)
        {
            spriteRenderer.flipX = true;
        }

        if (playerMovement.movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
