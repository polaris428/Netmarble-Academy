using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour
{
    player player;
    // Start is called before the first frame update
    void Start()
    {
        player= GameObject.Find("player").GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void jump()
    {
        player.jump = true;
        Invoke("jumpend", 0.5f);
    }
    public void jumpend()
    {
        player.jump = false;
    }
}
