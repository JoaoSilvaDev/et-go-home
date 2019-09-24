﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;

    [Tooltip("Range around character where player can grab items")]
    [SerializeField]
    private float range;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            GrabItem();
    }

    void GrabItem()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.gameObject.CompareTag("Item"))
            {
                var item = hit.transform.GetComponent<Item>();

                if(item != null)
                {
                    CollectItem(item);
                }
            }
        }
    }

    private void CollectItem(Item item)
    {
        item.Collect();
        _inventory.AddItem(item);
    }
}
