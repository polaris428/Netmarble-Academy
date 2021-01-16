using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class computer : MonoBehaviour
{
    public Text ScriptTxt;
    public int a = 0;
    public int max = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        ScriptTxt.text = "퀘스트 : 컴퓨터 해킹 (" + a + "/" + max +")";

        if (a == max)
        {
            Debug.Log("퀘스트 성공");
        }
    }
    void Update()
    {
        
    }
}
