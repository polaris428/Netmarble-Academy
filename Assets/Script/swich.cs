using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityScript;






public class swich : MonoBehaviour
{
    public Sprite CurrentSprite;
    public Sprite NextSprite;
    private SpriteRenderer spriteRenderer;

    BoxCollider2D BoxCollider2D;
    Rigidbody2D rigid;
   
    Animator anim;
  

    //Set this in the Inspector
    public Sprite m_Sprite;

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
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = CurrentSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spriteRenderer.sprite = NextSprite;

            Debug.Log("asfdsaf");
   


            Invoke("ShinDayoung", 2);
            anim.speed = 0;
           

        }
    }
    void ShinDayoung()
    {
        BoxCollider2D.enabled = false;
    }
    
}
