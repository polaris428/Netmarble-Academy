using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[System.Serializable ]
public class Dialogue1
{



    [TextArea]
    public string Endialogue;
    public string Entitle;
    public Sprite Encg;
    public Sprite Encg2;
}
public class Ending : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] private SpriteRenderer sprite_StandingCG;
    [SerializeField] private SpriteRenderer sprite_StandingCG2;
    [SerializeField] private SpriteRenderer sprite_DialogueBox;

    [SerializeField] private Text text_Dialougue;
    [SerializeField] private Text text_Dialougue2;
    private bool isDialogue = false;

    private int count = 0;
    [SerializeField] private Dialogue1[] dialogue;
    // Start is called before the first frame update


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
        text_Dialougue2.text = dialogue[count].Endialogue;
        text_Dialougue.text = dialogue[count].Entitle;
        sprite_StandingCG.sprite = dialogue[count].Encg;
        sprite_StandingCG2.sprite = dialogue[count].Encg2;

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
    // Update is called once per frame
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Show();
    }

    void Update()
    {


        if (isDialogue)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (count < dialogue.Length)
                {
                    audioSource.Play();
                    Next();
                }
                else
                {   Hide();
                    SceneManager.LoadScene("GameEnd");
                    
                }
            }
        }
    }
}

