using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDamage : MonoBehaviour
{

    public int hitPoints = 2;
    public Sprite damagedSprite;
    public float damageImpactSpeed;

    private int currentHP;
    private float damageImpactSpeedSqr;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHP = hitPoints;
        damageImpactSpeedSqr = damageImpactSpeed * damageImpactSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Damager")
        {
            return;
        }
        if (collision.relativeVelocity.sqrMagnitude < damageImpactSpeedSqr)
        {
            return;
        }
        spriteRenderer.sprite = damagedSprite;
        currentHP--;

        if (currentHP <= 0)
        {
            Kill();
        }
    }

    void Kill()
    {
        spriteRenderer.enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        //collider2D.enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
    }
}
