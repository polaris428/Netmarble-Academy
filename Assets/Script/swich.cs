using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI;
public class swich : MonoBehaviour
{
   

    BoxCollider2D BoxCollider2D;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    Sprite sprite;
    // Start is called before the first frame update
    private void Awake()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<Sprite>();
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {   
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
