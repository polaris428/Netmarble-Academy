using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class robot : MonoBehaviour
{

    public AudioSource audioSource;
    // Start is called before the first frame update

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    // Update is called once per frame
    BoxCollider2D BoxCollider2D;
    public float movePower=1;
    Animator animator;
    Vector3 movement;
    int movementFlag = 0;
    bool isTracing;
    GameObject traceTarget;
    public string dist = "";
    bool moving = true;
    public int wrring=0;
    public int wrringmax = 10;
    void Awake()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    // Use this for initialization
    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        StartCoroutine("ChangeMovement");
    }

    IEnumerator ChangeMovement()
    {
        movementFlag = Random.Range(0, 3);

        

        yield return new WaitForSeconds(3f);

        StartCoroutine("ChangeMovement");
    }

    // Update is called once per frame
    void FixedUpdate(){
        
        if(dist== "Right")
        {
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.right, 5, LayerMask.GetMask("Player"));
        
            
                Debug.DrawRay(rigid.position, Vector3.right, new Color(300, 300, 0));
                if (rayHit.collider != null)
                {
                    Debug.Log("Afafsfdsaf");
                    anim.SetBool("iswrring", true);
                    Invoke("Wrring", 1f);
            }
                else
                {
                    wrring = 0;
                    anim.SetBool("iswrring", false);

            }
            
        }
        if (dist == "Left")
        {
             RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.left, 5, LayerMask.GetMask("Player"));
                   
                        Debug.DrawRay(rigid.position, Vector3.left, new Color(300, 300, 0));
                        if (rayHit.collider != null)
                        {
                            
                            Debug.Log("Afafsfdsaf");
                            anim.SetBool("iswrring", true);
                            Invoke("Wrring", 1f);

            }
             else
                    {
                        anim.SetBool("iswrring", false);
                    }
        }
       

        if (moving==true)
        {
            Move();
        }        
       
        
    }
    void Wrring()
    {
        wrring++;
       
        if (wrring >= 100)
        {
            Debug.Log("게임 종료");
            
        } 
        
    }
    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        

        if (isTracing)
        {
            Vector3 playerPos = traceTarget.transform.position;

            if (playerPos.x < transform.position.x)
            {
                dist = "Left";
               
            }



            else if (playerPos.x > transform.position.x)
            {
                dist = "Right";
            }
              
        }
        else
        {
            if (movementFlag == 1)
                dist = "Left";
            else if (movementFlag == 2)
                dist = "Right";
        }

        if (dist == "Left")
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (dist == "Right")
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
        };

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            traceTarget = other.gameObject;

            StopCoroutine("ChangeMovement");
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            isTracing = true;
            animator.SetBool("isMoving", true);


        }


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            ShinDayoung();

            anim.SetBool("Destruction", true);


        }


    }
    void ShinDayoung()
    {
        audioSource.Play();
        //rigid.isKinematic = true;
        moving = false;
        //BoxCollider2D.enabled = false;
        this.gameObject.layer = 14;
    }


}
