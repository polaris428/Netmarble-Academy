using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class player : MonoBehaviour
{
    public float maxSpeed;
    public float Jumppow;

    public float Dashpow;
    public float startDashTime;

    float currenDashTimer;
    float DashDirecttion;

    bool isDashing;

    public float movX;
    
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    void Awake()
    {
        
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void jump()
    {
        anim.SetBool("isJumping", false);
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump")&& !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * Jumppow, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
            Invoke("jump", 1);
            
        }


        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
            
            

        }
        if (Input.GetButtonDown("Horizontal"))
        {
            
            
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
            movX = -1;
            

        }
        
        if (Mathf.Abs( rigid.velocity.x )<0.1)
        
            anim.SetBool("iswarking", false);
        
        else
        
            anim.SetBool("iswarking", true);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {    anim.SetBool("isDash", true);

            isDashing = true;
            currenDashTimer = startDashTime;
            rigid.velocity = Vector2.zero;
            DashDirecttion = movX;




            
        }
        if (isDashing)
        {
            rigid.velocity = transform.right * DashDirecttion * Dashpow;

            currenDashTimer -= Time.deltaTime;
            if (currenDashTimer <= 0)
            {
                isDashing = false;
                anim.SetBool("isDash", false);
            }
        }
       
    }
    void FixedUpdate()
    {

        
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if(rigid.velocity.x > maxSpeed)
        {
            movX = 1;
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
           
        }
        
            

        else if (rigid.velocity.x < maxSpeed * (-1))
        {
            movX =- 1;
            rigid.velocity = new Vector2(maxSpeed*(-1), rigid.velocity.y);

        }
        
            

        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1,LayerMask.GetMask("Tilemap"));
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            
            if (rayHit.collider != null)
                    {
                        if (rayHit.distance < 0.5f)
                            anim.SetBool("isJumping", false);
                    }
        }
        
      
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            OnDamaged();
        }
    }
    void OnDamaged()
    {
        anim.SetBool("New Bool", true);
        Debug.Log("게임 오버");
       
    }

}
