using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class swich : MonoBehaviour
{

    Newrobot n1;
    Newrobot n2;
    Newrobot n3;

    Rigidbody2D rigid;
    button b;

    Animator animator;
    public GameObject myObject;
    public Sprite newSprite;
    public AudioSource audioSource;
    
    //Set this in the Inspector



    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        b = GameObject.Find("Button").GetComponent<button>();
       

    }
   
    void Start()
    {
        // swich.GetComponent<Newrobot>().pow();

        //a = GameObject.Find <"ObjectName">().GetComponent<ScriptName>().MethodName();
 
 n1 = GameObject.Find("newrobot1").GetComponent<Newrobot>();
        n2 = GameObject.Find("newrobot2").GetComponent<Newrobot>();
        n3 = GameObject.Find("newrobot3").GetComponent<Newrobot>();
    

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        RaycastHit2D rayHit2 = Physics2D.Raycast(rigid.position, Vector3.left, 2, LayerMask.GetMask("Player"));
        RaycastHit2D rayHit3 = Physics2D.Raycast(rigid.position, Vector3.right, 2, LayerMask.GetMask("Player"));
        Debug.DrawRay(rigid.position, Vector3.left, new Color(600, 300, 0));


        if ((rayHit2.collider != null || rayHit3.collider != null) && b.mutual)
        {


            animator.enabled = false;
                        audioSource.Play();
                        myObject.GetComponent<SpriteRenderer>().sprite = newSprite;
                        n1.pow();
                        n2.pow();

                        n3.pow();





        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player"&&b.mutual)
        {

            



        }
    }
    
}
