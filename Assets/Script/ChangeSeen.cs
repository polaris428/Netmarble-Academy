using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSeen : MonoBehaviour
{
    // Start is called before the first frame update
 

public void StageChose()
    {
        SceneManager.LoadScene("StageChose");
    }
    public void SampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void SceneChangetitle()
    {
        SceneManager.LoadScene("maintitle");
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}


