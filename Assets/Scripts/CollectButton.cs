using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private int mapSceneIndex;

    private void Start()
    {
        button.onClick.AddListener(Collect);
    }

    private void Collect()
    {
        ItemCollector.CollectItem();
        SceneManager.LoadScene(mapSceneIndex);
    }
}
