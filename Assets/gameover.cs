using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameover : MonoBehaviour
{
    public Text ScriptTxt;
    int a = 0;
    public bool b = false;
    public GameObject UI;
    public GameObject Playrt;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (b)
        {
            UI.SetActive(false);
            Playrt.SetActive(false);


            switch (a)
            {
                case 0:
                    ScriptTxt.text = "Adsfaf";
                    break;
                case 1:
                    ScriptTxt.text = "ㅇㄻㄹㄹ";
                    break;
                case 2:
                    ScriptTxt.text = "FDASFASFA";
                    break;
            }


        }

    }
}
