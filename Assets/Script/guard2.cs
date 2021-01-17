using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guard2 : MonoBehaviour
{// Start is called before the first frame update
    wrring w;
    public float movePower;
    //Animator animator;
    Vector3 movement;
    int movementFlag = 0;
    bool isTracing;
    GameObject traceTarget;
    Rigidbody2D rigid;
    Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        //animator = GetComponentInChildren<Animator>();
        w = GameObject.Find("EventSystem").GetComponent<wrring>();
        StartCoroutine("ChangeMovement");
    }
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

            if (!w.wrringmod)
            {
                w.wrringmod = true;
            }
            else
            {
                w.count++;
            }


        }
    }
    IEnumerator ChangeMovement()
    {
        movementFlag = Random.Range(0, 3);

        //if (movementFlag == 0)
            //animator.SetBool("isMoving", false);
       // else
            //animator.SetBool("isMoving", true);

        yield return new WaitForSeconds(3f);

        StartCoroutine("ChangeMovement");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        string dist = "";

        if (isTracing)
        {
            Vector3 playerPos = traceTarget.transform.position;

            if (playerPos.x < transform.position.x)
                dist = "Left";
            else if (playerPos.x > transform.position.x)
                dist = "Right";
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
            transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);

        }
        else if (dist == "Right")
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1.3f, 1.3f, 13f);
        };

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    
    
}









