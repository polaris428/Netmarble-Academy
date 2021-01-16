using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using PathCreation;
public class player : MonoBehaviour
{


    public AudioSource dash;



    public bool adf;


    private bool isOnGround = true;
    private bool isOnGround2 = true;
    private float verticalSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float jumpTime;
    private float jumpTimeCounter;
    private bool isJumping = false;

    [SerializeField]
    private Transform feetPos;
    [SerializeField]
    private float checkRadius;
    [SerializeField]
    private LayerMask groundType;
    public LayerMask groundType2;
    public float maxSpeed;
    public float Jumppow;
    public float Dashpow;
    public float startDashTime;

    float currenDashTimer;
    float DashDirecttion;

    bool isDashing;

    public float movX;

    private float checkDistance=10;
    /* warp 관련 변수들
     * 
     * warp 하는 위치, 현재 위치 등을 저장하는 변수들입니다.
     * */
    [SerializeField]
    private PathCreator pathCreator;

    [SerializeField]
    public EndOfPathInstruction end;

    private bool isWarping = false;
    private bool warpDirection;
    [SerializeField]
    private float speed;

    private float warpDistance;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    void Awake()
    {
        
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    /*void jump()
    {
        anim.SetBool("isJumping", false);
    }*/
    void Update()
    {   
        if (maxSpeed < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
           
        }
        else if (maxSpeed > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            
        }


        #region WARP
        //Debug.Log("wapp");
        if (isWarping)
        {
           // Debug.Log("warping");
            if (warpDirection)
            {   

                warpDistance += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(warpDistance, end);
                if (pathCreator.path.length < warpDistance)
                {   
                    isWarping = false;
                    rigid.velocity = new Vector2(0.0f, 0.0f);
                    transform.position = pathCreator.path.GetPoint(pathCreator.path.localPoints.Length - 1);
                    Debug.Log("warp ended!");
                    anim.SetBool("iselectrick", false);
                }
            }
            else
            {      
                
                warpDistance -= speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(warpDistance, end);
                if (0 > warpDistance)
                {
                   
                    isWarping = false;
                    rigid.velocity = new Vector2(0.0f, 0.0f);
                    transform.position = pathCreator.path.GetPoint(0);
                    Debug.Log("warp ended!");
                    anim.SetBool("iselectrick", false);
                }
            }

        }
        else if (Input.GetKey(KeyCode.E))
        {
            //Debug.Log("Key.E");
            GameObject[] pathCreators;
            pathCreators = GameObject.FindGameObjectsWithTag("ElectricPath");
            //Debug.Log("count " + pathCreators.Length);

            Vector3 currentPosition = transform.position;
            foreach (GameObject electricPath in pathCreators)
            {

                PathCreator currentPath = electricPath.GetComponent<PathCreator>();

                //Debug.Log("current position : " + currentPosition);

                //Vector3 startPosition = currentPath.path.GetPoint(0) + currentPath.transform.position;
                Vector3 diff = currentPath.path.GetPoint(0) - currentPosition;
                float currentDistance = diff.sqrMagnitude;

               // Debug.Log("start point " + currentPath.path.GetPoint(0) + " distance ->" + currentDistance);

                if (currentDistance < checkDistance)
                {
                    anim.SetBool("iselectrick", true);
                    pathCreator = currentPath;
                    warpDistance = 0;
                    warpDirection = true;
                    isWarping = true;
                   // Debug.Log("warp started!");
                    break;
                }

                //Vector3 endPosition = currentPath.path.GetPoint(1) + currentPath.transform.position;
                diff = currentPath.path.GetPoint(currentPath.path.localPoints.Length - 1) - currentPosition;
                currentDistance = diff.sqrMagnitude;
               // Debug.Log("length : " + currentPath.path.length);
                //Debug.Log("end point " + currentPath.path.GetPoint(currentPath.path.localPoints.Length - 1) + " distance ->" + currentDistance);

                if (currentDistance < checkDistance)
                {
                    anim.SetBool("iselectrick", true);
                    pathCreator = currentPath;
                    warpDistance = currentPath.path.length;
                    warpDirection = false;
                    isWarping = true;
                   // Debug.Log("warp started reverse!");
                    break;
                }
            }
        }

        #endregion
        isOnGround = Physics2D.OverlapCircle(feetPos.position, checkRadius, groundType);
        isOnGround2 = Physics2D.OverlapCircle(feetPos.position, checkRadius, groundType2);
        // 지정해둔 땅에 있으면서 스페이스바를 누르고 있고, 발이 충분히 땅에 닿아 있으면 점프를 합니다.
        if ((isOnGround2 || isOnGround) && Input.GetKeyDown(KeyCode.Space) && !isWarping)
        {
            isJumping = true;
            anim.SetBool("isJumping", true);
            jumpTimeCounter = jumpTime;
            rigid.AddForce(Vector2.up * Jumppow, ForceMode2D.Impulse);
        }

        if (!isJumping || isWarping)
        {
            anim.SetBool("isJumping", false);
            
        }




            // 스페이스바 키를 떼는 순간 점프가 끊기도록 합니다.
            if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        /*if (Input.GetButtonDown("Jump")&& !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * Jumppow, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
            Invoke("jump", 1);
            
        }*/


        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
            
            

        }
        if (Input.GetButtonDown("Horizontal"))
        {
            
            
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
            movX = -1;
            

        }
        
        if (Mathf.Abs( rigid.velocity.x) < 0.1)
        {
            anim.SetBool("iswarking", false);anim.SetBool("isbox", false);
        }
        
            

            

        else
        
            anim.SetBool("iswarking", true);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {    

            isDashing = true;
            currenDashTimer = startDashTime;
            rigid.velocity = Vector2.zero;
            DashDirecttion = movX;
            anim.SetBool("isDash", true);
            dash.Play();
            


            
        }
        if (isDashing)
        {
            rigid.velocity = transform.right * DashDirecttion * Dashpow;
            currenDashTimer -= Time.deltaTime;
            if (currenDashTimer <= 0)
            {
                isDashing = false;
                anim.SetBool("isDash", false);
            }
        }
       
    }
    void FixedUpdate()
    {
        

        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if(rigid.velocity.x > maxSpeed)
        {
             anim.SetBool("isbox", false);
            movX = 1;
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
           


        }
        
            

        else if (rigid.velocity.x < maxSpeed * (-1))
        {
              anim.SetBool("isbox", false);
            movX =- 1;
            rigid.velocity = new Vector2(maxSpeed*(-1), rigid.velocity.y);

          

        }
        
            

        
      
        
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "box")
        {


            anim.SetBool("isbox",true);
           


        }
        else
        {
             Debug.Log("kjdfjhfdkjhlaf");
        }


    }
}

    


