using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Dialogue : MonoBehaviour
{
    [TextArea(1, 5)]
    public string[] sentences;
    public Text dialogueText;

    public UnityEvent FinishedDialogue;

    private int sentenceIndex = 0;

    public void Start()
    {
        dialogueText.text = sentences[sentenceIndex];
    }

    public void NextSentence()
    {
        sentenceIndex++;

        if (sentenceIndex > sentences.Length - 1)
            FinishedDialogue.Invoke();
        else
            dialogueText.text = sentences[sentenceIndex];
    }
}
