using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public string[] sentences;
    public Text dialogueText;

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
            SceneManager.LoadScene(sceneToLoad);

        }
        else
        {
            dialogueText.text = sentences[sentenceIndex];
            Debug.Log("Changed sentence");
        }
    }
}
