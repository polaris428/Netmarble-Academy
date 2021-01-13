using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class keymoon : MonoBehaviour
{
    Rigidbody2D rigid;
    BoxCollider2D BoxCollider2D;

    public AudioSource audioSource;

    Animator anim;
    public GameObject myObject;

    
    //Set this in the Inspector

    public Sprite newSprite;
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            
                 audioSource.Play();
            
                           anim.SetBool("card",true);
                            Invoke("open", 2f);

            
          


        }

    }
    void open()
    {
       
        anim.enabled = false;

        BoxCollider2D.enabled = false; myObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        
    }
}