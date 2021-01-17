using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    computer a;
    button b;
    public AudioSource haking;
    BoxCollider2D BoxCollider2D;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    bool polairs = false;

    public bool c = false;
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
        a = GameObject.Find("computer").GetComponent<computer>();
        b = GameObject.Find("Button").GetComponent<button>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {

        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.left, 20, LayerMask.GetMask("Player"));
        RaycastHit2D rayHit2 = Physics2D.Raycast(rigid.position, Vector3.right, 20, LayerMask.GetMask("Player"));
        Debug.DrawRay(rigid.position, Vector3.left, new Color(600, 300, 0));


        if ((rayHit.collider != null|| rayHit2.collider!= null) && b.mutual)
        {
            BoxCollider2D.enabled = false;


            anim.SetBool("a", true);
            haking.Play();
            if (polairs == false)
            {
                polairs = true;
                a.a++;

            }



        }

    }






}


