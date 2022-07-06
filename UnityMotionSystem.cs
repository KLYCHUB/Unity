using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;

    //Hareket işlemleri
    public float moveSpeed = 7.5f;
    public float horizontalSpeed;
    public float jumpSpeed = 107.5f, jumpFrequency= 0.1f, nextJumpTime;

    //Zemin işlemleri
    public Transform groundCheckPosition; //Zeminin pozisyonunun kontrolü
    public float groundCheckRadius= 0.1f; //Zeminin çap kontrolü
    public LayerMask groundCheckLayer; //Zeminin katman kontrolü
    public bool  isGrounded = false; //Zeminde olup olmadığının kontrolü

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HorizontalSpeed();
        OnGroundCheck();
        FacingRight();
        Jump();
    }

    void HorizontalSpeed()
    {
        horizontalSpeed = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalSpeed * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            rb.AddForce(new Vector2(0f, jumpSpeed * 10)); //Büyük sayılarla uğraşmamak için 10 ile çarptım
        }
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer); //Physics2D.OverlapCircle(pozisyonu, çapı, katmanı);
    }

    void FacingRight()
    {

        Vector2 newScale = transform.localScale;

        if (horizontalSpeed > 0)
        {
            newScale.x = 0.2031988f;
        }
        if (horizontalSpeed < 0)
        {
            newScale.x = -0.2031988f;
        }

        transform.localScale = newScale;
    }
}

//Metodları yazarken her kelime büyük harfle başlar

//1. Playerin altında IsGroundCheck adında gameobject oluşturun ve o oluşturduğunuz objeji playere atadığınız bu scriptdeki IsGroundCheck kısmına sürükleyin
//1.1 Bunu gizmoya çevirim karekterin zeminle temas ettiği yerin tam orta böygesine yerleştirin
//2. Move Speed -> 7.5 (İsteğe bağlı)
//3 Horizontal Speed -> 0 -> bu scriptin için de boş değer bırakın
//4. Jump Speed -> 107.5 (İsteğe bağlı)
//5. Jump Frequency -> 0.1
//6. Next Jump Time -> 0 -> bu scriptin için de boş değer bırakın
//7. Ground Check Radius -> 0.1
//8. Ground Check Layerı ground seçin -> bunun için zemininize ground layeri atayın (oyuncunuzun Player layerinde olduğuna dikkat edin)
