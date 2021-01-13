using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    BoxCollider2D BoxCollider2D;
    public AudioSource audioSource;
    bool a=true;
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    
    
    
    void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.tag == "Player")
            {       audioSource.Play();
                    
            }else
            {
               // Debug.Log("나랏말싸미 동국에달아");
                audioSource.loop = false;
                audioSource.Stop();
           
            }
    }
    void Update()
    {
        
    }
}
