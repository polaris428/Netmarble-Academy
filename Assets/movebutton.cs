using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movebutton : MonoBehaviour
{
    player p;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        p = GameObject.Find("player").GetComponent<player>();
    }


    // Update is called once per frame
    void Update()
    {

    }
    public void leftdown()
    {
        p.move = 2;
    }
    public void Rightdown()
    {
        p.move = 1;
    }
    public void up()
    {
        p.move = 0;
        
    }
}
