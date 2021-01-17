using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrring : MonoBehaviour
{
    gameover gameover;


    public GameObject myObject;
    public GameObject myObject2;
    public bool wrringmod = false;
    public bool play = false;
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameover = GameObject.Find("Gameover").GetComponent<gameover>();

    }

    // Update is called once per frame
    void Update()
    {
        if (count >= 2)
        {
            gameover.b = true;
            Debug.Log("게임종료");
        }
        if (wrringmod == true)
        {

            if (play == false)
            {
                    playwrring();
            }
         

        }


        void playwrring()
        {
            play = true;
            myObject.layer = 18;
           
        }
    }
}
