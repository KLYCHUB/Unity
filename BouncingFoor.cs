using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGround : MonoBehaviour
{
    public float JumpForce = 100f;

    private void OnCollisionEnter2D(Collision2D collision) //collision-> temas
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Vector2 jumpForceVelocity = rb.velocity;
            jumpForceVelocity.y = JumpForce;
            rb.velocity = jumpForceVelocity;
        }
    }
}
