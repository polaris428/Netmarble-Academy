using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guard : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    wrring w;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        w = GameObject.Find("EventSystem").GetComponent<wrring>();
    }

    // Update is called once per frame
    void Update()
    {
        if (w.wrringmod)
        {
            anim.SetBool("iswrring", true);
        }
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.left, 4, LayerMask.GetMask("Player"));

        Debug.DrawRay(rigid.position, Vector3.left, new Color(300, 300, 0));
        if (rayHit.collider != null)
        {
            
   
            anim.SetBool("iswrring", true);

        }
    }
    
}
