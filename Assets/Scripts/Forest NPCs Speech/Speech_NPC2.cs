using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;
using TMPro;
using UnityEngine.UIElements;

public class Speech_NPC2 : MonoBehaviour
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
            "Through the door is a dungeon",
            "It's kinda scary... but there are a lot of cool crystals in there.",
            "There are 5 of them, make sure to collect them all!",
            "...but Watch Out; there's a bunch of scary guys patrolling... don't let them hurt you!"
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
