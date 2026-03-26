using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;
using TMPro;
using UnityEngine.UIElements;

public class SpeechBubbleControl : MonoBehaviour
{
    
    private Vector3 offset;

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
            "Hi! This is dialogue. Click me again to hear me talk more!",
            "Here's another line of dialogue!",
            "More dialogue!",
            "Click me one more time to make me shut up! (And click me again after to restart my whole spiel!)"
        };
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnMouseDown()
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
