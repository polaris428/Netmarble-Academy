using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guard : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    public int wrring = 0;
    public int wrringmax = 10;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.left, 4, LayerMask.GetMask("Player"));

        Debug.DrawRay(rigid.position, Vector3.left, new Color(300, 300, 0));
        if (rayHit.collider != null)
        {
            Wrring();
            Debug.Log("Afafsfdsaf");
            anim.SetBool("iswrring", true);

        }
    }
    void Wrring()
    {
        wrring++;
        if (wrring >= 10)
        {
            Debug.Log("게임 종료");

        }
    }
}
