using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class KarenFinalDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;    
    public Transform player;

    public string[] lines;
    public string endSceneName;

    public float interactDistance = 3f;

    private int index = 0;
    private bool isTalking = false;
    private bool isLastLine = false;

    void Start()
    {
        dialogueText.text = "";
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        // Start dialogue when near Karen
        if (distance < interactDistance && Input.GetKeyDown(KeyCode.E) && !isTalking)
        {
            StartDialogue();
        }

        if (!isTalking) return;

        // Go to next line
        if (Input.GetKeyDown(KeyCode.E) && !isLastLine)
        {
            NextLine();
        }

        // Final line → go to end screen
        if (Input.GetKeyDown(KeyCode.Space) && isLastLine)
        {
            dialoguePanel.SetActive(false);
            SceneManager.LoadScene(endSceneName);
        }
    }

    void StartDialogue()
    {
        isTalking = true;
        index = 0;
        isLastLine = false;

        dialoguePanel.SetActive(true); // SHOW PANEL
        dialogueText.text = lines[0];
    }

    void NextLine()
    {
        index++;

        if (index < lines.Length - 1)
        {
            dialogueText.text = lines[index];
        }
        else
        {
            dialogueText.text = lines[index] + "\n\n< Press Space to continue >";
            isLastLine = true;
        }
    }
}