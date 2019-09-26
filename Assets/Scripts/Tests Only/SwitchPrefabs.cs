using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPrefabs : MonoBehaviour
{
    public GameObject[] objs;

    int index;

    private void Update()
    {
        if (objs.Length == 0)
            return;

        if(Input.touchCount == 3 && Input.touches[2].phase == TouchPhase.Began)
        {

            for (int i = 0; i < objs.Length; i++)
            {
                if (i == index)
                    objs[i].SetActive(true);
                else
                    objs[i].SetActive(false);
            }

            index = (index +1) % objs.Length;
        }
    }
}
