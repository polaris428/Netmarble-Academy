using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    
public class player : MonoBehaviour
{   
    
    
     // 2초 뒤에 실행 } }
    public float movePower = 1f;
    public float jumpPower = 1f;
    
    Rigidbody2D rigidbody;

    Vector3 movement;
    bool isjumping = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            isjumping = true;
        }
    }
    private void FixedUpdate()
    {
        Move();
        Jump();
    }
    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
        }else if(Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
        }
        transform.position += moveVelocity * movePower * Time.deltaTime;
    }
    void Jump()
    {
        if (!isjumping)
            return;
        rigidbody.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumpPower);
        rigidbody.AddForce(jumpVelocity, ForceMode2D.Impulse);
      
        isjumping = false;
    }
}
