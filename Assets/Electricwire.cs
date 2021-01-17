using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electricwire : MonoBehaviour
{
    // Start is called before the first frame update
    public bool polair = false;
    player p;
    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.Find("player").GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void wire()
    {
        p.ele = true;
        Invoke("log", 0.5f);
    }
    public void log()
    {
        p.ele = false;
    }



    public void dash()
    {
        p.dashhh = true;
        


    }
    public void fdash()
    {
        p.dashhh = false;
    }
    public void Mutual()
    {
        polair = true;
    }
    public void noMutual()
    {
        polair = false;
    }
}
