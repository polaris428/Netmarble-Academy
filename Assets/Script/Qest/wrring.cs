using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrring : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public GameObject myObject;
    public bool wrringmod = false;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wrringmod == true)
        {
            
            
                myObject.layer = 18;
                spriteRenderer.color = new Color(1, 1, 1, 0.4f);

            
        }
    }
}
