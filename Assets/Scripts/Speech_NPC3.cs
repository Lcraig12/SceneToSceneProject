using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;
using TMPro;
using UnityEngine.UIElements;

public class Speech_NPC3 : MonoBehaviour
{
    string[] dialogues;
    public int dialogueIndex;
    public GameObject currentNPC;
    public TextMeshProUGUI dialogueText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueIndex = -1;
        dialogueText.text = " ";
        dialogues = new string[] {
            "They're gonna Get you",
            "Don't touch the bad guys you're gonna take damage it's gonna suck bro",
            "I warned you"
        };
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(gameObject.tag == "ForestNPC")
            {
                dialogueIndex++;
                if(dialogueIndex >= dialogues.Length)
                {
                    dialogueIndex = -1;
                    dialogueText.text = " ";
                }
                else
                {
                    dialogueText.text = dialogues[dialogueIndex];
                }  
            }
        }  
    }
}
