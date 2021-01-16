using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
   public bool sellp = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gotosleep()
    {
        sellp = true;
        Invoke("log",0.5f);
    }
    public void log()
    {
        sellp = false;
    }
}
