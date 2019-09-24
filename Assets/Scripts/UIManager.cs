using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject finishUI;
    public GameObject givePieceButton;

    public void GivePieceButton()
    {
        givePieceButton.SetActive(false);
        finishUI.SetActive(true);
    }
}
