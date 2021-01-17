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

    wrring wrring;
    // Start is called before the first frame update
    void Start()
    {
            UI.SetActive(false);
            Playrt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        
           
            switch (a)
            {
                case 0:
                    ScriptTxt.text = "다음부터는 더 조심히 하겠습니다…";
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
