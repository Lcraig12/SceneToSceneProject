using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;
using TMPro;
using UnityEngine.UIElements;

public class Speech_NPC4 : MonoBehaviour
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
            "Who are you",
            "I think I'm lost I don't know where I am",
            "Who are you people??",
            "Help!"
        };
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnMouseDown()
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
