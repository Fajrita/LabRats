using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpriteFlip : MonoBehaviour
{
    FindTarget playerMovement;
    SpriteRenderer spriteRenderer;
    Vector2 lastPosition;
    void Start()
    {
        playerMovement = GetComponentInParent<FindTarget>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
        lastPosition = playerMovement.movement;
        if (lastPosition.x < 0)
        {
            spriteRenderer.flipX = true;
        }

        if (lastPosition.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
