using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class button : MonoBehaviour
{
   public bool mutual = false;
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

        mutual = true;
        Invoke("log",0.5f);
    }
    public void log()
    {
        mutual = false;
    }

    public void replay()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Seen()
    {
        SceneManager.LoadScene("StageChose");
    }
    





}
