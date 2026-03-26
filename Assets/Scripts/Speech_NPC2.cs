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
            "Do you like shiny crystals? I like shiny crystals.",
            "You should collect all the crystals in the next room!",
            "There are 5 of them, make sure to collect them all!",
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
