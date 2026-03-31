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
            "After you get all the gems, you gotta escape... they're gonna be after you",
            "You better run back to your house once you're out of the dungeon. Or else bad things will happen.",
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
