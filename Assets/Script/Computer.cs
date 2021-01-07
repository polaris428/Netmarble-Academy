using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    BoxCollider2D BoxCollider2D;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
       


    } 
    void OnCollisionEnter2D(Collision2D collision)
        { 
         if (collision.gameObject.tag == "Player")
        {

            Invoke("ShinDayoung", 2);

            anim.SetBool("a", true);
                    
           
        }
    }
    void ShinDayoung()
    {
        BoxCollider2D.enabled = false;
    }

}
