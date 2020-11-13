using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class robot : MonoBehaviour
{
    public float movePower = 1f;
    Animator animator;  
    Vector3 movement;
    int moevemenFlag = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        StartCoroutine("ChangeMovment");
    }

    // Update is called once per frame
    
    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        if (moevemenFlag == 1)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);

        }
        else if(moevemenFlag == 2){
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, -1, -1);
        }
        transform.position += moveVelocity * movePower * Time.deltaTime;
    }
}
