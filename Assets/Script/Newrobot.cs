using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Newrobot : MonoBehaviour
{
    Rigidbody2D rigid;
    public GameObject myObject;
    public Sprite newSprite;
     Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        //pow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pow()
    {   

        Debug.Log("성공");
        anim.SetBool("off", true);
        Debug.Log("전원꺼짐");
        anim.enabled = false;
        myObject.GetComponent<SpriteRenderer>().sprite = newSprite;


    }
    private void FixedUpdate()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 10, LayerMask.GetMask("Player"));


        Debug.DrawRay(rigid.position, Vector3.down, new Color(300, 300, 0));
        if (rayHit.collider != null)
        {

            Debug.Log("걸렸다");
           
        }
        else
        {
            
            anim.SetBool("iswrring", false);

        }
        
    }
}
