using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keybox : MonoBehaviour
{

    button b;
    public GameObject item;
    public GameObject box;
    public AudioSource audioSource;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        b = GameObject.Find("Button").GetComponent<button>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player" && b.mutual)
    //    {

    //        audioSource.Play();
    //        item.SetActive(true);
    //        box.SetActive(false);


    //    }

    //}

    private void FixedUpdate()
    {

        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.left, 2, LayerMask.GetMask("Player"));
        RaycastHit2D rayHit2 = Physics2D.Raycast(rigid.position, Vector3.right, 2, LayerMask.GetMask("Player"));
        Debug.DrawRay(rigid.position, Vector3.left, new Color(600, 300, 0));


        if ((rayHit.collider != null || rayHit2.collider != null) && b.mutual)
        {



                    audioSource.Play();
                   item.SetActive(true);
                    box.SetActive(false);






        }

    }
}
