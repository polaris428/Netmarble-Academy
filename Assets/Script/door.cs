using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class door : MonoBehaviour
{
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.right, 5, LayerMask.GetMask("Player"));

        Debug.DrawRay(rigid.position, Vector3.right, new Color(300, 300, 0));
        if (rayHit.collider != null)
        {
            Debug.Log("af");
            SceneManager.LoadScene("StageChose");
        }

    }
}
