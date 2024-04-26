using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipRecieveDamage : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
    }

    
    void Update()
    {
        if (spriteRenderer.flipX)
        {
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        if (!spriteRenderer.flipX)
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

}

