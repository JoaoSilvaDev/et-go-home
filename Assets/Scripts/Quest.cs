using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class Quest : MonoBehaviour
{
    [TextArea(1, 5)]
    public string[] sentences;
    public Text dialogueText;

    public UnityEvent FinishedDialogue;
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
            FinishedDialogue.Invoke();
        else
            dialogueText.text = sentences[sentenceIndex];
    }
}
