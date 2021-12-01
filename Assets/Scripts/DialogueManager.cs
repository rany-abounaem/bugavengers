using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI buttonText;
    int currentDialogueIndex = 1;
    public int maxDialogueIndex;
    public Dialogue[] dialogues;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ContinueDialogue()
    {
        if (currentDialogueIndex > maxDialogueIndex)
        {
            QuitDialogue();
            return;
        }
        dialogueText.text = dialogues[currentDialogueIndex].text;
        buttonText.text = dialogues[currentDialogueIndex].continueButton;
        currentDialogueIndex++;
    }

    public void QuitDialogue()
    {
        dialoguePanel.SetActive(false);
        GameManager.instance.inputEnabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.inputEnabled = false;
    }
}
