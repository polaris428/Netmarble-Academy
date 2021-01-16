using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class door : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.right, 3, LayerMask.GetMask("Player"));

        Debug.DrawRay(rigid.position, Vector3.right, new Color(300, 300, 0));
        if (rayHit.collider != null)
        {
            anim.SetBool("open", true);
            Invoke("open",1.5f);
        }

    }
    void open()
    {
            SceneManager.LoadScene("StageChose2");
    }
}
