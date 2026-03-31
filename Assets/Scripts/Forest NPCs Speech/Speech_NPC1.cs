using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;
using TMPro;
using UnityEngine.UIElements;

public class SpeechBubbleControl : MonoBehaviour
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
            "Hi! Welcome to the forest! Me and my friends have something we want you to do for us.",
            "You should talk to all my friends back there, they'll explain.",
            "Once you're done, interact with the door behind you! (Hover mouse + Press E)",
            "Press E on me one more time to make me shut up! (And press E on me again after to restart my whole spiel!)"
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
