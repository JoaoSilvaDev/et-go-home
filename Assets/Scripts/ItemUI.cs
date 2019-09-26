using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image[] icons;

    private void Start()
    {
        Inventory.onAddItem += OnItemCollected;
    }

    private void OnDestroy()
    {
        Inventory.onAddItem -= OnItemCollected;
    }

    private void OnEnable()
    {
        var items = Inventory.GetItems();
        foreach (var item in items)
        {
            OnItemCollected(item);
        }
    }

    public void OnItemCollected(int id)
    {
        Color col = icons[id].color;
        col.a = 1;
        icons[id].color = col;
    }
}
