using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cctv : MonoBehaviour
{
    BoxCollider2D BoxCollider2D;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    public GameObject myObject;
    public Sprite newSprite1;
    public Sprite newSprite2;


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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Invoke("ShinDayoung", 1f);

            


        }
    }
    void ShinDayoung()
    {
        
        myObject.GetComponent<SpriteRenderer>().sprite = newSprite1;
        Invoke("ShinSoobin", 1f);

    }
    void ShinSoobin()
    {
        myObject.GetComponent<SpriteRenderer>().sprite = newSprite2;
        BoxCollider2D.enabled = false;
    }
}
