using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keymoon : MonoBehaviour
{
    public AudioSource audioSource;
    SpriteRenderer spriteRenderer;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.Play();
            anim.SetBool("card",true);
            anim.enabled = false;



        }

    }
}