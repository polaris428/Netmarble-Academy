using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class swich : MonoBehaviour
{

    Newrobot a;
    
    
    Animator animator;
    public GameObject myObject;
    public Sprite newSprite;
    public AudioSource audioSource;

    //Set this in the Inspector

    

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();



    }
   
    void Start()
    {
        // swich.GetComponent<Newrobot>().pow();

        //a = GameObject.Find <"ObjectName">().GetComponent<ScriptName>().MethodName();
        a=GameObject.Find("newrobot1").GetComponent<Newrobot>();
        

    

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
            audioSource.Play();
            myObject.GetComponent<SpriteRenderer>().sprite = newSprite;
            a.pow();






        }
    }
    
}
