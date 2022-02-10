using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossRoomDialogue : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.CompareTag("PossessedRobot"))
        {
            GameManager.instance.inputEnabled = false;
        }
       

    }
}
