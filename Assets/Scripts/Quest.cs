using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    [TextArea(1, 5)]
    public string[] sentences;
    public Text dialogueText;
    public GameObject questUI;

    public int sceneToLoad;

    private int sentenceIndex = 0;

    public void Start()
    {
        dialogueText.text = sentences[sentenceIndex];
    }

    public void ChangeSentence()
    {
        sentenceIndex++;

        if (sentenceIndex > sentences.Length - 1)
        {
            questUI.SetActive(false);
        }
        else
        {
            dialogueText.text = sentences[sentenceIndex];
            Debug.Log("Changed sentence");
        }
    }
}
