using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl2 : MonoBehaviour
{
    public float yatayHareket;
    public float hareketHizi;
    public float ziplamaHizi;

    public bool noJumpGround = true;

    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        yatayHareket = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(yatayHareket * hareketHizi * 100 * Time.deltaTime, rb.velocity.y);
        rb.velocity = Vector2.up * ziplamaHizi * 100 * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * ziplamaHizi * 100 * Time.deltaTime;
            noJumpGround = false;
        }

        FacingRight();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            noJumpGround = true;
        }
    }

    void FacingRight()
    {

        Vector2 newScale = transform.localScale;

        if (yatayHareket > 0)
        {
            newScale.x = 0.2031988f;
        }
        if (yatayHareket < 0)
        {
            newScale.x = -0.2031988f;
        }

        transform.localScale = newScale;
    }
}
