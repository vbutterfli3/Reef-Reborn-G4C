using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CutsceneTextSequence : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    [TextArea]
    public string[] lines;

    public string nextSceneName;

    private int index = 0;
    private bool isLastLine = false; 

    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = lines[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isLastLine)
        {
            NextLine();
        }

        if(Input.GetKeyDown(KeyCode.Space) && isLastLine)
        {
            SceneManager.LoadScene(nextSceneName);
        }
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
            dialogueText.text = lines[index] + "\n\n< Press Space Bar to Continue >";
            isLastLine = true;
        }
    }
}
