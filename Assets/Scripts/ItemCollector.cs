using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    // Range around character where player can grab items
    public float range;

    void Update()
    {
        if (Input.touchCount > 0)
            GrabItem();
    }

    void GrabItem()
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.CompareTag("Item"))
                {
                    Debug.Log("Collected " + hit.collider.gameObject.GetComponent<Item>().title);
                }
            }
        }
    }
}
