﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class swich : MonoBehaviour
{
    Animator animator;
    public GameObject myObject;
    Newrobot newrobot;
    public GameObject robot1;
    
    //Set this in the Inspector

    public Sprite newSprite;

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();



    }
   
    void Start()
    {
       // swich.GetComponent<Newrobot>().pow();
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            animator.enabled = false;
            Debug.Log("asfdsaf");
            myObject.GetComponent<SpriteRenderer>().sprite = newSprite;



            
           
           

        }
    }
    
}
