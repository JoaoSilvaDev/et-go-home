using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    private void Update()
    {
        if (Input.touchCount == 3 && Input.touches[2].phase == TouchPhase.Began)
        {
            int index = SceneManager.GetActiveScene().buildIndex +1;
            index = index % SceneManager.sceneCount;
            SceneManager.LoadScene(index);
        }
    }
}
