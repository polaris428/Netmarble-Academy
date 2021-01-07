using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[System.Serializable]
public class Dialogue2
{
    [TextArea]
    public string dialogue;
    public string title;
    public Sprite cg;
    public Sprite cg2;
}
public class seen1 : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite_StandingCG;
    [SerializeField] private SpriteRenderer sprite_StandingCG2;
    [SerializeField] private SpriteRenderer sprite_DialogueBox;

    [SerializeField] private Text text_Dialougue;
    [SerializeField] private Text text_Dialougue2;
    private bool isDialogue = false;

    private int count = 0;
    [SerializeField] private Dialogue[] dialogue;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;



    public void Show()
    {   
        sprite_DialogueBox.gameObject.SetActive(true);
        sprite_StandingCG.gameObject.SetActive(true);
        sprite_StandingCG2.gameObject.SetActive(true);
        text_Dialougue.gameObject.SetActive(true);
        text_Dialougue2.gameObject.SetActive(true);
        count = 0;
        isDialogue = true;
        Next();
    }
    private void Next()
    {
        text_Dialougue2.text = dialogue[count].dialogue;
        text_Dialougue.text = dialogue[count].title;
        sprite_StandingCG.sprite = dialogue[count].cg;
        sprite_StandingCG2.sprite = dialogue[count].cg2;
        count++;

    }
    private void Hide()
    {
        
        sprite_DialogueBox.gameObject.SetActive(false);
        sprite_StandingCG.gameObject.SetActive(false);
        sprite_StandingCG2.gameObject.SetActive(false);
        text_Dialougue.gameObject.SetActive(false);
       
       
        text_Dialougue2.gameObject.SetActive(false);
       

    }
    // Start is called before the first frame update
    void Awake()
    {   rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
   
    private void FixedUpdate()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.left, 5, LayerMask.GetMask("Player"));

        Debug.DrawRay(rigid.position, Vector3.left, new Color(300, 300, 0));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (count==1)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
        
        
        
        if (count == 0)
        {
                if (rayHit.collider != null)
                        {
           
                            Debug.Log(count);
                            Show();
                            if (isDialogue)
                            {
                                if (Input.GetKeyDown(KeyCode.Space))
                                {
                                    if (count < dialogue.Length)
                                    {
                                        Next();
                                    }
                                    else
                                    {
                                       
                                       
                                        Hide();
                                        
                                        
                        
                                    }
                                }
                            }
        }
        
        






        }
    }
}
