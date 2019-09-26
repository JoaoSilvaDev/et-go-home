using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private int sceneIndex = 0;
    [SerializeField] private bool loadOnEnable = false;

    private void OnEnable()
    {
        if (loadOnEnable)
            Load();
    }

    public void Load()
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void Load(int index)
    {
        SceneManager.LoadScene(index);
    }
}
